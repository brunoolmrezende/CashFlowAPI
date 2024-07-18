using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;
using PaymentType = CashFlow.Domain.Enums.PaymentType;

namespace CashFlow.Application.UseCases.Expenses.Report.Excel
{
    public class GenerateExcelReportExcelJsonUseCase : IGenerateExcelReportExcelJsonUseCase
    {
        private readonly IExpensesReadOnlyRepository _repository;
        public GenerateExcelReportExcelJsonUseCase(IExpensesReadOnlyRepository repository)
        {
            _repository = repository;
        }
        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);
            if (expenses.Count == 0)
            {
                return [];
            }

            var workbook = new XLWorkbook();

            workbook.Author = "Bruno Rezende";
            workbook.Style.Font.FontSize = 12;
            workbook.Style.Font.FontName = "Times Nwe Roman";

           var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

            InsertHeader(worksheet);

            var row = 2;
            foreach (var expense in expenses)
            {
                worksheet.Cell($"A{row}").Value = expense.Title;
                worksheet.Cell($"B{row}").Value = expense.Date;
                worksheet.Cell($"C{row}").Value = ConvertPaymentType(expense.PaymentType);
                worksheet.Cell($"D{row}").Value = expense.Amount;
                worksheet.Cell($"E{row}").Value = expense.Description;

                row++;
            }

            var file = new MemoryStream();
            workbook.SaveAs(file);

            return file.ToArray();
        }
        
        private string ConvertPaymentType(PaymentType payment)
        {
            return payment switch
            {
                PaymentType.Cash => ResourceConvertPaymentType.CASH,
                PaymentType.CreditCard => ResourceConvertPaymentType.CREDIT_CARD,
                PaymentType.DebitCard => ResourceConvertPaymentType.DEBIT_CARD,
                PaymentType.Pix => ResourceConvertPaymentType.PIX,
                _ => string.Empty
            };
        }
        private void InsertHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
            worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DATE;
            worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
            worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
            worksheet.Cell("E1").Value = ResourceReportGenerationMessages.DESCRIPTION;

            worksheet.Cells("A1:E1").Style.Font.Bold = true;

            worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");

            worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        }
    }
}

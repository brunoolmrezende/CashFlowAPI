
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Report.Excel
{
    public class GenerateExcelReportExcelJsonUseCase : IGenerateExcelReportExcelJsonUseCase
    {
        public async Task<byte[]> Execute(DateOnly month)
        {
            var workbook = new XLWorkbook();

            workbook.Author = "Bruno Rezende";
            workbook.Style.Font.FontSize = 12;
            workbook.Style.Font.FontName = "Times Nwe Roman";

           var worksheet = workbook.Worksheets.Add(month.ToString("Y"));
        }
    }
}

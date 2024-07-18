
using CashFlow.Application.UseCases.Expenses.Report.Pdf.Fonts;
using CashFlow.Domain.Repositories.Expenses;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Expenses.Report.Pdf
{
    public class GenerateReportPdfJsonUseCase : IGenerateReportPdfJsonUseCase
    {
        private readonly IExpensesReadOnlyRepository _repository;
        public GenerateReportPdfJsonUseCase(IExpensesReadOnlyRepository repository)
        {
            _repository = repository;

            GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
        }
        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);
            if (expenses.Count == 0)
            {
                return [];
            }

            return [];
        }
    }
}

namespace CashFlow.Application.UseCases.Expenses.Report.Pdf
{
    public interface IGenerateReportPdfJsonUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}

namespace CashFlow.Application.UseCases.Expenses.Report.Excel
{
    public interface IGenerateReportExcelJsonUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}

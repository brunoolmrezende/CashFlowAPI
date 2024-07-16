namespace CashFlow.Application.UseCases.Expenses.Report.Excel
{
    public interface IGenerateExcelReportExcelJsonUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}

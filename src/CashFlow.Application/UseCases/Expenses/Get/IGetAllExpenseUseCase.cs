using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Get
{
    public interface IGetAllExpenseUseCase
    {
        Task<ResponseExpensesJson> Execute();
    }
}

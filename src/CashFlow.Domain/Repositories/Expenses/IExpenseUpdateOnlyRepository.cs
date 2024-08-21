using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseUpdateOnlyRepository
    {
        Task<Expense?> GetById(Entities.User user ,long id);
        void Update(Expense expense);
    }
}

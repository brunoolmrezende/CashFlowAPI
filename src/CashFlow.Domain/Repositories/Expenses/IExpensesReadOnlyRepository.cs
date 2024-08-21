using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesReadOnlyRepository
    {     
        Task<List<Expense>> GetAll(Entities.User user);
        Task<Expense?> GetById(long id, Entities.User user);
        Task<List<Expense>> FilterByMonth(DateOnly month);
    }
}


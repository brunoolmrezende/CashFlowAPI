namespace CashFlow.Communication.Responses
{
    public class ResponseShortExpensesJson
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Decimal Amount { get; set; }
    }
}

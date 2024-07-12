namespace CashFlow.Exception.ExceptionsBase
{
    public class NotFoundException : CashFlowApiException
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}

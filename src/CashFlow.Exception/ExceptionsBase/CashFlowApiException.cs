namespace CashFlow.Exception.ExceptionsBase;
public abstract class CashFlowApiException : SystemException
{
    protected CashFlowApiException(string message) : base(message)
    {
        
    }
}

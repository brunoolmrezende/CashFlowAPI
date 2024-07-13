namespace CashFlow.Exception.ExceptionsBase;
public abstract class CashFlowApiException : SystemException
{
    protected CashFlowApiException(string message) : base(message)
    {
        
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();

}

namespace CashFlow.Communication.Requests
{
    public class RequestChangePasswordJson
    {
        public string Password { get; set; } = String.Empty;
        public string NewPassword { get; set; } = String.Empty;
    }
}

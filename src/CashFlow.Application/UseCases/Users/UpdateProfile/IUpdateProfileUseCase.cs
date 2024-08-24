using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Users.UpdateProfile
{
    public interface IUpdateProfileUseCase
    {
        Task Execute(RequestUserUpdateJson request);
    }
}


using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Services.LoggedUser;

namespace CashFlow.Application.UseCases.Users.DeleteProfile
{
    public class DeleteProfileUseCase : IDeleteProfileUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProfileUseCase(
            ILoggedUser loggedUser,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _loggedUser = loggedUser;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute()
        {
            var user = await _loggedUser.Get();

            await _userWriteOnlyRepository.Delete(user);

            await _unitOfWork.Commit();
        }
    }
}

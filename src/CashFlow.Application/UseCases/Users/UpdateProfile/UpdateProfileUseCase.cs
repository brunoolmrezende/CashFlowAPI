using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Users.UpdateProfile
{
    public class UpdateProfileUseCase : IUpdateProfileUseCase
    {
        private readonly ILoggedUser _loggedUser;
        IUserUpdateOnlyRepository _userUpdateOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProfileUseCase(
            ILoggedUser loggedUser,
            IUserUpdateOnlyRepository userUpdateOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _loggedUser = loggedUser;
            _userReadOnlyRepository = userReadOnlyRepository;
            _unitOfWork = unitOfWork;
            _userUpdateOnlyRepository = userUpdateOnlyRepository;
        }
        public async Task Execute(RequestUserUpdateJson request)
        {
            var loggedUser = await _loggedUser.Get();

            await Validate(request, loggedUser.Email);

            var user = await _userUpdateOnlyRepository.GetById(loggedUser.Id);

            user.Name = request.Name;
            user.Email = request.Email;

            _userUpdateOnlyRepository.Update(user);

            await _unitOfWork.Commit();
        }

        private async Task Validate(RequestUserUpdateJson request, string currentEmail)
        {
            var validator = new UpdateUserValidator();
            
            var result = validator.Validate(request);

            if (currentEmail.Equals(request.Email) == false)
            {
                var emailIsUsed = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
                if (emailIsUsed)
                    result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_EXISTS));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(errors => errors.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}

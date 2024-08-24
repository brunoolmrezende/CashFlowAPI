using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Users.ChangePassword
{
    public class ChangePasswordUseCase : IChangePasswordUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserUpdateOnlyRepository _userUpdateOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncripter _passwordEncripter;

        public ChangePasswordUseCase(
            ILoggedUser loggedUser,
            IPasswordEncripter passwordEncripter,
            IUserUpdateOnlyRepository userUpdateOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _loggedUser = loggedUser;
            _passwordEncripter = passwordEncripter;
            _unitOfWork = unitOfWork;
            _userUpdateOnlyRepository = userUpdateOnlyRepository;
        }
        public async Task Execute(RequestChangePasswordJson request)
        {
            var loggedUser = await _loggedUser.Get();

            Validate(request, loggedUser);

            var user = await _userUpdateOnlyRepository.GetById(loggedUser.Id);
            user.Password = _passwordEncripter.Encrypt(request.Password);

            _userUpdateOnlyRepository.Update(user);

            await _unitOfWork.Commit();
        }

        private void Validate(RequestChangePasswordJson request, User loggedUser)
        {
            var validator = new ChangePasswordValidator();

            var result = validator.Validate(request);

            var passwordMatch = _passwordEncripter.Verify(request.Password, loggedUser.Password);

            if (passwordMatch is false)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.PASSWORD_DIFFERENT_CURRENT_PASSWORD));
            }

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(errors => errors.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}

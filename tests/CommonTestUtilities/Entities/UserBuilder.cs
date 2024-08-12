using Bogus;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Cryptography;

namespace CommonTestUtilities.Entities
{
    public class UserBuilder
    {
        public static User Build()
        {
            var passwodEncripter = PasswordEncripterBuilder.Build();

            var user = new Faker<User>()
                .RuleFor(user => user.Id, _ => 1)
                .RuleFor(user => user.Name, faker => faker.Person.FirstName)
                .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Email))
                .RuleFor(user => user.Password, (_, user) => passwodEncripter.Encrypt(user.Password))
                .RuleFor(user => user.UserIdentifier, _ => Guid.NewGuid());

            return user;
        }
    }
}

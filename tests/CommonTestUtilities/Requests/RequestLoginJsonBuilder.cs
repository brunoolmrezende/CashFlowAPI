using Bogus;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestLoginJsonBuilder
    {
        public static RequestLoginJson Build()
        {
            return new Faker<RequestLoginJson>()
                .RuleFor(user => user.Email, Faker => Faker.Internet.Email())
                .RuleFor(user => user.Password, Faker => Faker.Internet.Password(prefix: "!Aa1"));
        }
    }
}

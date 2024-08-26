using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;

namespace CashFlow.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToRequest();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(dest => dest.Password, config => config.Ignore());

            CreateMap<RequestExpenseJson, Expense>()
                .ForMember(dest => dest.Tags, config => config.MapFrom(source => source.Tags.Distinct()));

            CreateMap<Communication.Enums.Tag, Domain.Entities.Tag>()
                .ForMember(dest => dest.Value, config => config.MapFrom(source => source));
        }

        private void EntityToRequest()
        {
            CreateMap<Expense, ResponseRegisteredExpenseJson>();
            CreateMap<Expense, ResponseShortExpensesJson>();
            CreateMap<Expense, ResponseExpenseJson>();
            CreateMap<User, ResponseUserProfileJson>();
        }
    }
}

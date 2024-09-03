using AutoMapper;
using Messaging.Shared;
using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;

namespace ReportingService.Core.Models.Responses;

public class MappingResponseProfile : Profile
{
    public MappingResponseProfile()
    {
        CreateMap<TransactionDto, TransactionResponse>().ForMember(dest => dest.LeadId, opt => opt.MapFrom(src => src.Account.LeadId));
        CreateMap<LeadDto, LeadsBirthDateResponse>();
        CreateMap<LeadDto, LeadResponse>();
        CreateMap<AccountNegativBalanceDto, NegativBalanceResponse>();
    }
}


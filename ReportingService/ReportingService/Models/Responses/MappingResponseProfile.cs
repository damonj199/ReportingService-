using AutoMapper;
using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;

namespace ReportingService.Core.Models.Responses;

public class MappingResponseProfile : Profile
{
    public MappingResponseProfile()
    {
        CreateMap<TransactionDto, TransactionResponse>().ForMember(dest => dest.LeadId, opt => opt.MapFrom(src => src.Account.LeadId));
        CreateMap<TransactionDto, TransactionWithAccountIdResponse>();
        CreateMap<LeadDto, LeadsBirthDateResponse>();
        CreateMap<LeadDto, LeadResponse>();
        CreateMap<LeadDto, LeadsFromStatusUpdate>();
        CreateMap<AccountDto, AccountForStatusUpdateResponse>();
        CreateMap<AccountNegativBalanceDto, NegativBalanceResponse>();
    }
}


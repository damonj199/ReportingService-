using AutoMapper;
using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;

namespace ReportingService.Core.Models.Responses;

public class MappingResponseProfile : Profile
{
    public MappingResponseProfile()
    {
        CreateMap<TransactionDto, TransactionResponse>();
        CreateMap<TransactionDto, TransactionWithAccountIdResponse>();
        CreateMap<LeadDto, LeadsBirthDateResponse>();
        CreateMap<LeadDto, LeadResponse>();
        CreateMap<LeadDto, LeadsFromStatusUpdate>();
        CreateMap<LeadMinDto, LeadsFromStatusUpdate>();
        CreateMap<AccountDto, AccountForStatusUpdateResponse>();
        CreateMap<AccountNegativBalanceDto, NegativBalanceResponse>();
    }
}


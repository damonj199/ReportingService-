using AutoMapper;
using ReportingService.Bll.Models.Responses;
using ReportingService.Core.Dtos;

namespace ReportingService.Core.Models.Responses;

public class MappingResponseProfile : Profile
{
    public MappingResponseProfile()
    {
        CreateMap<TransactionDto, TransactionResponse>();
        CreateMap<LeadDto, LeadForStatusUpdateResponse>();
        CreateMap<LeadDto, LeadResponse>();
        CreateMap<AccountDto, AccountResponse>();
        CreateMap<AccountNegativBalanceDto, NegativBalanceResponse>();
    }
}


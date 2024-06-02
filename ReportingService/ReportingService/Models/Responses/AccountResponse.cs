using ReportingService.Core.Dtos;
using ReportingService.Core.Enums;

namespace ReportingService.Bll.Models.Responses;

public class AccountResponse
{
    public Guid Id { get; set; }
    public CurrencyType Currency { get; set; }
    public AccountStatus Status { get; set; }
    public LeadDto Leads { get; set; }
    public List<TransactionDto> Transactions { get; set; }
}

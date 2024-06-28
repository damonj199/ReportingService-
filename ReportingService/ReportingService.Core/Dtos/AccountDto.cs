using ReportingService.Core.Enums;

namespace ReportingService.Core.Dtos;

public class AccountDto
{
    public Guid Id { get; set; }
    public CurrencyType Currency { get; set; }
    public AccountStatus Status { get; set; }
    public LeadDto Lead { get; set; }
    public List<TransactionDto> Transactions { get; set; }
    public Guid LeadId { get; set; }
}

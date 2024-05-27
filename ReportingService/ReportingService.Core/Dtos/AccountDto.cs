using ReportingService.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ReportingService.Core.Dtos;

public class AccountDto
{
    public Guid Id { get; set; }
    public CurrencyType Currency {  get; set; }
    public AccountStatus Status { get; set; }
    public LeadDto Leads { get; set; }
    public List<TransactionDto> Transactions { get; set; }
}

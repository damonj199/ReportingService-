using ReportingService.Core.Emums;
using System.ComponentModel.DataAnnotations;

namespace ReportingService.Core.Dtos;

public class AccountsDto
{
    [Key]
    public Guid Id { get; set; }
    public CurrencyType Currency {  get; set; }
    public AccountStatus Status { get; set; }
    public LeadsDto Leads { get; set; }
    public List<TransactionsDto> Transactions { get; set; }
}

using ReportingService.Core.Emums;
using System.ComponentModel.DataAnnotations;

namespace ReportingService.Core.Dtos;

public class TransactionsDto
{
    [Key]
    public Guid Id { get; set; }
    public AccountsDto AccountsId { get; set; }
    public TransactionType TransactionType { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
}

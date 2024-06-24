using ReportingService.Core.Enums;

namespace ReportingService.Core.Dtos;

public class TransactionDto
{
    public Guid Id { get; set; }
    public AccountDto Account { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}

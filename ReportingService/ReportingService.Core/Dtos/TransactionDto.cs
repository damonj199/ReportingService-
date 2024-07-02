using ReportingService.Core.Enums;

namespace ReportingService.Core.Dtos;

public class TransactionDto
{
    public Guid Id { get; set; }
    public AccountDto Account { get; set; }
   
    public TransactionType TransactionType { get; set; }
    public Currency? Currency { get; set; }
    public decimal Amount { get; set; }
    public decimal Comission { get; set; } = 0;
    public DateTime Date { get; set; }
}

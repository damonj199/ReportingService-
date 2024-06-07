namespace ReportingService.Core.Dtos;

public class AccountNegativBalanceDto
{
    public Guid AccountId { get; set; }
    public decimal Sum { get; set; }
}

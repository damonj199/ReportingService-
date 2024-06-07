namespace ReportingService.Bll.Models.Responses;

public class NegativBalanceResponse
{
    public Guid AccountId { get; set; }
    public decimal Sum { get; set; }
}

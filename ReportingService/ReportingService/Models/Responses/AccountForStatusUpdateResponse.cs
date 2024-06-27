using ReportingService.Core.Dtos;

namespace ReportingService.Bll.Models.Responses;

public class AccountForStatusUpdateResponse
{
    public Guid Id { get; set; }
    public Guid Lead { get; set; }
    public List<TransactionDto> Transactions { get; set; }
}

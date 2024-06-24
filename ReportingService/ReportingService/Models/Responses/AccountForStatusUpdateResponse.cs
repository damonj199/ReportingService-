using ReportingService.Core.Dtos;
using ReportingService.Core.Enums;

namespace ReportingService.Bll.Models.Responses;

public class AccountForStatusUpdateResponse
{
    public Guid Id { get; set; }
    public LeadDto Lead { get; set; }
    public List<TransactionDto> Transactions { get; set; }
}

using ReportingService.Core.Dtos;
using ReportingService.Core.Enums;

namespace ReportingService.Bll.Models.Responses;

public class LeadForStatusUpdateResponse
{
    public Guid Id { get; set; }
    public LeadStatus Status { get; set; }
    public DateOnly BirthDate { get; set; }
    //public List<AccountDto> Accounts { get; set; }
}

using ReportingService.Core.Enums;

namespace ReportingService.Core.Dtos;

public class StatusHistory
{
    public Guid Id { get; set; }
    public LeadDto Lead { get; set; }
    public LeadStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}

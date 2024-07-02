using ReportingService.Core.Enums;

namespace ReportingService.Core.Dtos;

public class LeadUpdatedDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Phone { get; init; }
    public string? Address { get; init; }
    public DateOnly? BirthDate { get; init; }
    public LeadStatus? Status { get; init; }
}

using ReportingService.Core.Enums;

namespace ReportingService.Core.Dtos;

public class LeadDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public DateOnly? BirthDate { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }
    public LeadStatus? Status { get; set; }
    public List<AccountDto>? Accounts { get; set; }
    public List<StatusHistoryDto>? StatusHistory { get; set; }
}

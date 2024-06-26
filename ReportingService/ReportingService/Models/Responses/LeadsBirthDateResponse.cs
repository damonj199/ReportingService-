namespace ReportingService.Bll.Models.Responses;

public class LeadsBirthDateResponse
{
    public Guid Id { get; set; }
    public DateOnly BirthDate { get; set; }
}

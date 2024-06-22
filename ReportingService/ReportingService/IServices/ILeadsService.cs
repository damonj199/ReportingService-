using ReportingService.Bll.Models.Responses;

namespace ReportingService.Bll.IServices;

public interface ILeadsService
{
    Task<LeadResponse> GetLeadFullInfoByIdAsync(Guid Id);
    Task<List<LeadsBirthDateResponse>> GetLeadsWithBirthdayTodayAsync();
    Task<List<LeadsFromStatusUpdate>> LeadWithTransactionsResponseAsync(int countDays);
}

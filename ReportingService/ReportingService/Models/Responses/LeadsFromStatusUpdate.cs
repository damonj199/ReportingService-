using ReportingService.Core.Dtos;
using ReportingService.Core.Enums;

namespace ReportingService.Bll.Models.Responses;

public class LeadsFromStatusUpdate
{
    public Guid Id { get; set; }
    public List<AccountDto> Accounts { get; set; }
}

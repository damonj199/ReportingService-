using ReportingService.Core.Emums;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReportingService.Core.Dtos;

public class LeadsDto
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public Date BirthDate { get; set; }
    public LeadStatus Status { get; set; }
    public List<AccountsDto> Accounts { get; set; }
}

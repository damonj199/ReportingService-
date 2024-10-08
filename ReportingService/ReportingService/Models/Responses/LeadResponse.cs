﻿using ReportingService.Core.Dtos;
using ReportingService.Core.Enums;

namespace ReportingService.Bll.Models.Responses;

public class LeadResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateOnly BirthDate { get; set; }
    public LeadStatus Status { get; set; }
    public List<AccountDto> Accounts { get; set; }
}

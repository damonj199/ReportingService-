﻿using MassTransit;
using Messaging.Shared;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadCreatedConsumer : IConsumer<LeadCreated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadCreatedConsumer>();
    private readonly ILeadsService _leadService;

    public LeadCreatedConsumer(ILogger<LeadCreatedConsumer> logger, ILeadsService leadService)
    {
        _leadService = leadService;
    }
    public async Task Consume(ConsumeContext<LeadCreated> context)
    {
        _logger.Information("Received message: lead created {Text}", context.Message.Name);

        var lead = new LeadDto
        {
            Id = context.Message.Id,
            Name = context.Message.Name,
            Mail = context.Message.Mail,
            Address = context.Message.Address,
            Phone = context.Message.Phone,
            BirthDate = context.Message.BirthDate,
            Month = context.Message.BirthDate.Month,
            Day = context.Message.BirthDate.Day,
            Status = context.Message.Status,
        };

        await _leadService.AddLeadAsync(lead);
    }
}

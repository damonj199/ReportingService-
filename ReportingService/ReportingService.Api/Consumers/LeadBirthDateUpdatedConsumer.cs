using MassTransit;
using Messaging.Shared;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadBirthDateUpdatedConsumer :IConsumer<LeadBirthDateUpdated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadBirthDateUpdatedConsumer>();
    private readonly ILeadsService _leadService;

    public LeadBirthDateUpdatedConsumer(ILogger<LeadBirthDateUpdatedConsumer> logger, ILeadsService leadService)
    {
        _leadService = leadService;
    }
    public async Task Consume(ConsumeContext<LeadBirthDateUpdated> context)
    {
        _logger.Information("Received message: update Bdate {Text}", context.Message.BirthDate);

        var lead = new LeadDto
        {
            BirthDate = context.Message.BirthDate,
            Month = context.Message.BirthDate.Month,
            Day = context.Message.BirthDate.Day,
        };

        await _leadService.UpdateLeadAsync(lead);
    }
}

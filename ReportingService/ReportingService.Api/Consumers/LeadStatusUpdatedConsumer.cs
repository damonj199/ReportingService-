using MassTransit;
using Messaging.Shared;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadStatusUpdatedConsumer : IConsumer<LeadStatusUpdated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadStatusUpdatedConsumer>();
    private readonly ILeadsService _leadService;

    public LeadStatusUpdatedConsumer(ILogger<LeadStatusUpdatedConsumer> logger, ILeadsService leadService)
    {
        _leadService = leadService;
    }
    public async Task Consume(ConsumeContext<LeadStatusUpdated> context)
    {
        _logger.Information("Received message: update status {Text}", context.Message.Status);

        var lead = new LeadDto { Status = context.Message.Status };
        
        await _leadService.UpdateLeadAsync(lead);
    }
}

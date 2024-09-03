using MassTransit;
using Messaging.Shared;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadDeletedConsumer : IConsumer<LeadDeleted>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadDeletedConsumer>();
    private readonly ILeadsService _leadService;

    public LeadDeletedConsumer(ILogger<LeadDeletedConsumer> logger, ILeadsService leadService)
    {
        _leadService = leadService;
    }
    public async Task Consume(ConsumeContext<LeadDeleted> context)
    {
        _logger.Information("Received message: lead daleted {Text}", context.Message.Id);

        var lead = new LeadDto { Id = context.Message.Id };

        await _leadService.DeletedLeadAsync(lead);
    }
}

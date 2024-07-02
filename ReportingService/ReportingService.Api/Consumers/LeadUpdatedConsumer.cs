using MassTransit;
using Messaging.Shared;
using ReportingService.Bll.IServices;
using ReportingService.Core.Dtos;
using Serilog;

namespace ReportingService.Api.Consumer;

public class LeadUpdatedConsumer : IConsumer<LeadUpdated>
{
    private readonly Serilog.ILogger _logger = Log.ForContext<LeadStatusUpdatedConsumer>();
    private readonly ILeadsService _leadService;

    public LeadUpdatedConsumer(ILogger<LeadUpdatedConsumer> logger, ILeadsService leadService)
    {
        _leadService = leadService;
    }
    public async Task Consume(ConsumeContext<LeadUpdated> context)
    {
        _logger.Information("Received message: updete lead info {Text}", context.Message.Id);
        
        var leadDto = new LeadDto 
        { 
            Id = context.Message.Id,
            Name = context.Message.Name,
            Phone = context.Message.Phone,
            Address = context.Message.Address
        };

        await _leadService.UpdateLeadAsync(leadDto);
    }
}

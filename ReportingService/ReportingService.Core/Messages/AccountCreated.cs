using ReportingService.Core.Enums;

namespace Messaging.Shared;

public class AccountCreated
{
    public Guid Id { get; init; }
    public CurrencyType Currency { get; init; }
    public AccountStatus Status { get; init; }
    public Guid LeadId { get; init; }
}

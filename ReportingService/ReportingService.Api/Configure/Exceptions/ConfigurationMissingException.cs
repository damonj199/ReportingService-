namespace ReportingService.Api.Configure.Exceptions;

public class ConfigurationMissingException(string message = "fault configuration") : Exception(message)
{
}

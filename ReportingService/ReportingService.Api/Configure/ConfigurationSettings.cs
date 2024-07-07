namespace ReportingService.Api.Configure;

public static class ConfigurationSettings
{
    public const string LogPath = "Serilog:WriteTo:0:Args:path";
    public const string DatabaseSettings = "DatabaseSettings";
    public const string ConfigurationServiceUrl = "https://194.87.210.5:13000/api/configuration?service=5";
    public const string DefaultConfigurationSection = "DefaultSettings";
}

namespace ReportingService.Api.Configure;

public static class ConfigurationSaver
{
    public static void SaveToEnvironmentVariables(Dictionary<string, string> config)
    {
        foreach (var kvp in config)
        {
            Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
        }
    }
}

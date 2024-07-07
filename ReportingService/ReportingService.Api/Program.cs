using ReportingService.Api.Configure;
using ReportingService.Api.Configure.Exceptions;
using ReportingService.Bll;
using ReportingService.Dal;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("appsettings.DefaultConfiguration.json", optional: false, reloadOnChange: true);
    await builder.Configuration.ReadSettingsFromConfigurationManager();

    Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
    builder.Logging.ClearProviders();

    builder.Services.ConfigureApiServices(builder.Configuration);
    builder.Services.ConfigureBllServices();
    builder.Services.ConfigureDalServices();

    var app = builder.Build();
    app.UseMiddleware<ExceptionMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    Log.Information("Running up.");
    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex.Message);
}
finally
{
    Log.CloseAndFlush();
}

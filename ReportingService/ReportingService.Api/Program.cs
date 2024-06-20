using MassTransit;
using ReportingService.Api.Configure;
using ReportingService.Api.Consumer;
using ReportingService.Bll;
using ReportingService.Core.Models.Requestes;
using ReportingService.Core.Models.Responses;
using ReportingService.Dal;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.ClearProviders();

    builder.Services.AddMassTransit(x =>
    {
        x.AddConsumer<Consumer>();

        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("rabbitmq://localhost", h =>
            {
                h.Username("guest");
                h.Password("guest");
            });

            cfg.ReceiveEndpoint("your_queue_name", e =>
            {
                e.ConfigureConsumer<Consumer>(context);
            });
        });
    });

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

    builder.Services.ConfigureApiServices(builder.Configuration);

    builder.Services.ConfigureDalServices();
    builder.Services.ConfigureBllServices();
    builder.Services.ConfigureDB(builder.Configuration);
    builder.Services.AddAutoMapper(typeof(MappingRequestProfile), typeof(MappingResponseProfile));


    var app = builder.Build();
    app.UseMiddleware<ExceptionMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex.Message);
}
finally
{
    Log.CloseAndFlush();
}

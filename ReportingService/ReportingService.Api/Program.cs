using MassTransit;
using ReportingService.Api.Configure;
using ReportingService.Bll;
using ReportingService.Core.Models.Requestes;
using ReportingService.Core.Models.Responses;
using ReportingService.Dal;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq();
});

Log.Logger = new LoggerConfiguration() //такой singleton на все приложение 
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger(); //

builder.Services.ConfigureApiServices(builder.Configuration);

builder.Services.ConfigureDalServices();
builder.Services.ConfigureBllServices();
builder.Services.ConfigureDB(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingRequestProfile), typeof(MappingResponseProfile));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

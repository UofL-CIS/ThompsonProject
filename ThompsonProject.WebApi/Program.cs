using Serilog;

using ThompsonProject.WebApi.Extensions;
using ThompsonProject.WebApi.Models;
using ThompsonProject.WebApi.Repos.Abstractions;
using ThompsonProject.WebApi.Repos.Concretions;
using ThompsonProject.WebApi.Services;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var settings = config
    .GetSection(nameof(AppSettings))
    .Get<AppSettings>();

var loggerConfig = new LoggerConfiguration()
        .WriteTo.Seq(
            serverUrl: settings.LoggingUri!,
            apiKey: settings.LoggingKey!)
        .ReadFrom.Configuration(config);

Log.Logger = loggerConfig.CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfiguration(config);
builder.Logging.AddSerilog(Log.Logger);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomHealthChecks();

builder.Services.AddSingleton<IVolunteerRepo>(_ => new VolunteerDal(config));

builder.Services.AddTransient<IVolunteerService, VolunteerService>();

try
{
    Log.Information("Application starting...");
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseVolunteerMappings();
    app.UseEventMappings();

    app.UseHealthChecks("/hc");

    Log.Information("Application started!");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start!");
    throw;
}
finally
{
    Log.CloseAndFlush();
}


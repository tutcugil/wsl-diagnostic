using Figensoft.NET.Framework.Configuration.Interface;
using Figensoft.NET.Framework.Extensions;
using Figensoft.NET.Framework.Logging;
using Figensoft.NET.Framework.Logging.Enums;

IConfiguration Configuration = new ConfigurationBuilder()
 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
 .AddEnvironmentVariables()
 .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFigensoftAppConfig(ServiceLifetime.Singleton);

builder.Services.AddFigensoftFileLogger(ServiceLifetime.Scoped, (provider) =>
{
    IConfig config = provider.GetRequiredService<IConfig>();

    return new FileLoggerOptions
    {
        Enabled = config.GetBool("Logging:Enabled", true),
        Project = config.GetString("App:Project"),
        App = config.GetString("App:Name"),
        Version = config.GetString("App:Version"),
        DefaultFolder = config.GetString("Logging:DefaultFolderName", "Trace"),
        DefaultFileName = config.GetString("Logging:DefaultFileName", "trace"),
        FilePath = config.GetString("Logging:FilePath"),
        MaxFileCount = config.GetInteger("Logging:MaxFileCount", 10),
        MaxFileSizeInMegaBytes = config.GetInteger("Logging:MaxFileSize", 100),
        LogFormatType = (LogFormatType)config.GetInteger("Logging:FormatType", (int)LogFormatType.CUSTOM),
        LogFormat = config.GetString("Logging:Format", "{TraceTime}|{Version}|{Type}|{IP}|{Port}|{RequestId}|{BatchId}|{SequenceId}|{UserId}|{Category}|{Message}|{StackTrace}"),
        ConfigPath = config.GetString("Config:Path")
    };
});
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapControllers();

app.Run();

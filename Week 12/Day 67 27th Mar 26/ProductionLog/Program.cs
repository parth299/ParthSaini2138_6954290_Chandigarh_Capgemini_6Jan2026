using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Mvc;
using ProductionLog.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<PerformanceLoggingFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Logs"));

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly()!);
var configPath = Path.Combine(Directory.GetCurrentDirectory(), "log4net.config");
XmlConfigurator.Configure(logRepository, new FileInfo(configPath));

var log = LogManager.GetLogger(typeof(Program));
log.Info("Application started");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
// dotnet add package Microsoft.Extensions.Hosting
// dotnet add package CsvHelper

// The following usings add the extensions for hosting.
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Adds reference to itself.
using DatabaseFun;
using DatabaseFun.Providers;
using DatabaseFun.Services;
using CSharpTodoListImporter.Models;

// Create host application builder.
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Add console JSON console logging to logging.
// THIS SHOULD BE SET W/ CONFIGURATION.
// builder.Logging.AddJsonConsole();
builder.Logging.AddConsole();
builder.Logging.AddFilter("Default", LogLevel.Debug);

// Add logging to injectable services.
builder.Services.AddLogging();

builder.Services.AddSingleton<IRecordReadProvider<Category>>(provider =>{
    var logger = provider.GetRequiredService<ILogger<CsvReadProvider<Category>>>();
    return new CsvReadProvider<Category>(logger, "../test-data/list-categories.csv");
    });
builder.Services.AddSingleton<ILoaderService<Category>, LoaderService<Category>>();

// Add primary app service to injectable services.
builder.Services.AddTransient<Service>();

// Build host.
using IHost host = builder.Build();

// Instantiate Program logger.
var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Starting up");

// Instantiate instance of console service.
var consoleService = host.Services.GetRequiredService<Service>();

var exitCode = await consoleService.RunService();
logger.LogInformation("Exiting with exit code {exitCode}.", exitCode);
Environment.Exit(exitCode);

// dotnet add package Microsoft.Extensions.Hosting
// dotnet add package CsvHelper

// The following usings add the extensions for hosting.
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Adds reference to itself.
using DatabaseFun;
using DatabaseFun.Models;
using DatabaseFun.Providers;
using DatabaseFun.Services;

// Create host application builder.
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Add console JSON console logging to logging.
// THIS SHOULD BE SET W/ CONFIGURATION.
// builder.Logging.AddJsonConsole();
builder.Logging.AddConsole();
builder.Logging.AddFilter("Default", LogLevel.Debug);

// Add logging to injectable services.
builder.Services.AddLogging();

var connectionString = "Server=localhost;Database=ToDoDB;User Id=sa;Password=Password7*test;Encrypt=True;TrustServerCertificate=True;";

builder.Services.AddSingleton<IRecordReadProvider<User>>(provider =>{
    var logger = provider.GetRequiredService<ILogger<SqlReadUserProvider>>();
    return new SqlReadUserProvider(logger, connectionString);
    });

builder.Services.AddSingleton<IRecordReadProvider<Category>>(provider =>{
    var logger = provider.GetRequiredService<ILogger<SqlReadCategoryProvider>>();
    return new SqlReadCategoryProvider(logger, connectionString);
    });

builder.Services.AddSingleton<IRecordReadProvider<ToDoItem>>(provider =>{
    var logger = provider.GetRequiredService<ILogger<SqlReadToDoItemProvider>>();
    return new SqlReadToDoItemProvider(logger, connectionString);
    });

builder.Services.AddSingleton<IRecordReadProvider<Category>>(provider =>{
    var logger = provider.GetRequiredService<ILogger<CsvReadProvider<Category>>>();
    return new CsvReadProvider<Category>(logger, "../test-data/list-categories.csv");
    });
    
builder.Services.AddSingleton<ILoaderService<Category>, LoaderService<Category>>();
builder.Services.AddSingleton<ILoaderService<User>, LoaderService<User>>();
builder.Services.AddSingleton<ILoaderService<ToDoItem>, LoaderService<ToDoItem>>();

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

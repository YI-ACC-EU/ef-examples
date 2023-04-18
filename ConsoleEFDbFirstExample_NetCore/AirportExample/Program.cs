using AirportExample.Repositories;
using AirportExample.Repositories.DbContexts;
using AirportExample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(app =>
    {
        app.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("Development") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .SetBasePath(Directory.GetCurrentDirectory());
    })
    .ConfigureServices((_, services) =>
    {
        var connectionString = _.Configuration.GetConnectionString("Airports");
        services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
            })
            .AddSingleton<ILoggerFactory, LoggerFactory>()
            .AddSingleton(typeof(ILogger<>), typeof(Logger<>))
            .AddDbContext<AirlinesDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                })
            .AddTransient<IFileSystemRepository, FileSystemRepository>()
            .AddTransient<IAirportsRepository, AirportsRepository>()
            .AddTransient<IAirportService, AirportService>()
            .AddTransient<IMainService, MainService>();
    })
    .Build();

using IServiceScope scope = host.Services.CreateScope();
var p = scope.ServiceProvider.GetRequiredService<IMainService>();
p.Run();
using AirportExample.Repositories;
using AirportExample.Repositories.DbContexts;
using AirportExample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

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
            .AddSingleton(loggerFactory)
            .AddSingleton(typeof(ILogger<>), typeof(Logger<>))
            .AddDbContext<AirlinesDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                    options.UseLoggerFactory(loggerFactory);
                })
            .AddTransient<IFileSystemRepository, FileSystemRepository>()
            .AddTransient<IPilotsRepository, PilotsRepository>()
            .AddTransient<IAirportsRepository, AirportsRepository>()
            .AddTransient<IAirportService, AirportService>()
            .AddTransient<IPilotService, PilotsService>()
            .AddTransient<IMainService, MainService>();
    })
    .Build();

using IServiceScope scope = host.Services.CreateScope();
var p = scope.ServiceProvider.GetRequiredService<IMainService>();
p.Run();
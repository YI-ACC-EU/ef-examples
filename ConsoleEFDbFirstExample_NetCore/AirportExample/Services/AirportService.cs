using AirportExample.Repositories;
using Microsoft.Extensions.Logging;

namespace AirportExample.Services;

public interface IAirportService
{
    void PrintByCountryCode(string countryCode);
}
public class AirportService : IAirportService
{
    private readonly ILogger<AirportService> _logger;
    private readonly IAirportsRepository _airportsRepository;
    public  AirportService(
        ILogger<AirportService> logger,
        IAirportsRepository airportsRepository
    )
    {
        _logger = logger;
        _airportsRepository = airportsRepository;
    }
    public void PrintByCountryCode(string countryCode)
    {
        try
        {
           var airportsResult = _airportsRepository.GetByCountryCode(countryCode);
           if(!airportsResult.IsSuccess) return;
           if(airportsResult.Content?.Any() != true)
               _logger.LogInformation($"No airports found for country code:{countryCode}");
           airportsResult.Content?.ForEach(airport =>
           {
               _logger.LogInformation($"{airport.AirportCode} - {airport.AirportName}");
           });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Can't print list of airports");
        }
    }
}
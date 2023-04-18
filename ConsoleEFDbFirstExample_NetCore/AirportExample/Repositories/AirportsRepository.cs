using AirportExample.Models;
using AirportExample.Models.Entities;
using AirportExample.Repositories.DbContexts;
using Microsoft.Extensions.Logging;

namespace AirportExample.Repositories;

public interface IAirportsRepository
{
    Result<List<Airport>> GetByCountryCode(string countryCode);
}

public class AirportsRepository : IAirportsRepository
{
    private readonly AirlinesDbContext _db;
    private readonly ILogger<AirportsRepository> _logger;

    public AirportsRepository(AirlinesDbContext dbContext, ILogger<AirportsRepository> logger)
    {
        _db = dbContext;
        _logger = logger;
    }

    public Result<List<Airport>> GetByCountryCode(string countryCode)
    {
        Result<List<Airport>> result;
        try
        {
            var airports = _db
                .Airports
                .Where(x=>x.CountryCode == countryCode)
                .ToList();
            result = Result<List<Airport>>.Create(airports);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            result = Result<List<Airport>>.CreateWithError(e.Message);
        }
        return result;
    }
}
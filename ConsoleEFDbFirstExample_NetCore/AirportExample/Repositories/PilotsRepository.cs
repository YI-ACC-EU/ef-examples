using AirportExample.Models.Entities;
using AirportExample.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AirportExample.Repositories;

public interface IPilotsRepository
{
    bool Insert(List<Pilot> pilots);
}

public class PilotsRepository : IPilotsRepository
{
    private readonly ILogger<PilotsRepository> _logger;
    private readonly AirlinesDbContext _db;

    public PilotsRepository(AirlinesDbContext context, ILogger<PilotsRepository> logger)
    {
        _logger = logger;
        _db = context;
    }

    public bool Insert(List<Pilot> pilots)
    {
        try
        {
            pilots.ForEach(pilot =>
            {
                var pm = pilot.PlaneModels.Select(x => x.ModelNumber);
                pilot.PilotId = 0;
                pilot.PlaneModels = new();
                pilot.PlaneModels = _db.PlaneModels.Where(x => pm.Contains(x.ModelNumber)).ToList();
                _db.Pilots.Add(pilot);
            });
            _db.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Can not insert pilots");
            return false;
        }
    }
}
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
                pilot.PilotId = 0;
                var plainModels = pilot.PlaneModels.Select(x => x.ModelNumber).ToArray();
                var planeModelsForPilot = _db.PlaneModels.Where(x => plainModels.Contains(x.ModelNumber)).ToList();
                var pilotFromDb = _db.Pilots.Add(pilot);
                _db.SaveChanges();
                pilotFromDb.Entity.PlaneModels.AddRange(planeModelsForPilot);
                _db.SaveChanges();
            });
            
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Can not insert pilots");
            return false;
        }
    }
}
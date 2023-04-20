using AirportExample.Extensions;
using AirportExample.Models.Entities;
using AirportExample.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AirportExample.Repositories;

public interface IPilotsRepository
{
    bool Insert(List<Pilot> pilots);
    void Query();
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
            var allModelsIds = pilots
                .SelectMany(x => x.PlaneModels)
                .Select(x => x.ModelNumber)
                .Distinct();

            var availableModels = _db.PlaneModels.Where(x => allModelsIds.Contains(x.ModelNumber)).ToList();
            pilots.ForEach(pilot =>
            {
                var pm = pilot.PlaneModels.Select(x => x.ModelNumber);
                pilot.PilotId = 0;
                pilot.PlaneModels = new();
                pilot.PlaneModels = availableModels.Where(x => pm.Contains(x.ModelNumber)).ToList();
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

    public void Query()
    {
        //SELECT DYNAMIC
        //Query1();

        ////LIKE
        //Query2();
        //Query2_1();
        //Query2_2();

        ////GROUP BY
        ////Planes by manufacturer
        //Query3();

        ////JOIN + GROUP BY
        //Query4();

        //JOIN EXAMPLES;
        //Query5();

        Query_6();
    }

    private void Query1()
    {
        //SELECT DYNAMIC

        var result = _db.Pilots
            .Select(x => x.FirstName + " " + x.LastName);
        _logger.LogInformation($"PILOTS ARRAY: { result.ToJson() }");
    }

    private void Query2()
    {
        //LIKE
        var result = _db.Pilots
            .Where(x => EF.Functions.Like(x.LastName, "%ar%"))
            .ToList();
        _logger.LogInformation($"LIKE RESULT: { result.ToJson() }");
    }
    private void Query2_1()
    {
        //var result = _db.Pilots
        //    .ToList() //NO!!!
        //    .Where(x => x.LastName.StartsWith("ar"));
            

        //LIKE
        var result = _db.Pilots
            .Where(x => x.LastName.StartsWith("ar"))
            .ToList();
        _logger.LogInformation($"LIKE RESULT: { result.ToJson() }");
    }

    private void Query2_2()
    {
        //LIKE
        var result = _db.Pilots
            .Where(x => x.LastName.EndsWith("ar"))
            .ToList();
        _logger.LogInformation($"LIKE RESULT: { result.ToJson() }");
    }

    private void Query3()
    {
        //GROUP BY
        //Planes by manufacturer
        var result = _db.PlaneModels
            .GroupBy(p => p.ManufacturerName)
            .Select(g => new { name = g.Key, count = g.Count() })
            .ToList();
        _logger.LogInformation($"GROUP BY RESULT: { result.ToJson() }");
    }

    private void Query4()
    {
        //JOIN + GROUP BY
        var result = _db.PlaneModels
            .Include(x => x.Pilots)
            .Select(x=> new { x.ManufacturerName, Pilots = x.Pilots.Select(p=> p.FirstName + " " + p.LastName)})
            .GroupBy(p => p.ManufacturerName)
            .Select(g => new
            {
                Manufacturer = g.Key, 
                Pilots = g.SelectMany(x=>x.Pilots)
            })
            .ToList();
        _logger.LogInformation($"JOIN RESULT2: { result.ToJson() }");
    }

    private void Query5()
    {
        var resultNoJoin = _db.PlaneModels
            .OrderBy(x=>x.ModelNumber)
            .FirstOrDefault();

        var resultWithPilotJoin = _db.PlaneModels
            .Include(x => x.Pilots)
            .OrderBy(x=>x.ModelNumber)
            .FirstOrDefault();

        var resultWithAllJoins = _db.PlaneModels
            .Include(x => x.Pilots).ThenInclude(x=>x.FlightInstanceCoPilotAboards)

            .Include(x=>x.PlaneDetails)
            .OrderBy(x=>x.ModelNumber)
            .FirstOrDefault();

        _logger.LogInformation($"JOIN RESULT - NO JOIN: { resultNoJoin.ToJson() }");
        _logger.LogInformation($"JOIN RESULT - PlainJoin JOIN: { resultWithPilotJoin.ToJson() }");
        _logger.LogInformation($"JOIN RESULT - AllJoin JOIN: { resultWithAllJoins.ToJson() }");
    }

    private void Query_6()
    {
       var result = _db.Flights
            .Include(x=>x.ArriveFrom).ThenInclude(x=>x.Country)
            .Include(x=>x.DepartTo).ThenInclude(x=>x.Country)
            .Where(x=>
                x.ArriveFrom.CountryCode == "NPL" ||
                x.DepartTo.CountryCode == "NPL")
            .Select(x=> new
            {
                x.FlightNo,
                From = x.ArriveFrom.Country.CountryName,
                To = x.DepartTo.Country.CountryName,
                x.Distance
            })
            .ToList();
       _logger.LogInformation($"Flights: { result.ToJson() }");
    }
}
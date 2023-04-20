using AirportExample.Models.Dto;
using AirportExample.Models.Entities;
using AirportExample.Repositories;
using Microsoft.Extensions.Logging;

namespace AirportExample.Services;

public interface IPilotService
{
    void ImportPilots();
    void Query();
}

public class PilotsService : IPilotService
{
    private IPilotsRepository _pilotsRepository;
    private IFileSystemRepository _fileSystemRepository;
    private ILogger<PilotsService> _logger;

    public PilotsService(
        IPilotsRepository pilotsRepository,
        IFileSystemRepository fileSystemRepository,
        ILogger<PilotsService> logger)
    {
        _pilotsRepository = pilotsRepository;
        _fileSystemRepository = fileSystemRepository;
        _logger = logger;
    }

    public void ImportPilots()
    {
        const string fileName = "DataFiles/pilots.json";

        //prendere dati da file
        var pilotsFromFileResult = _fileSystemRepository
            .Read<List<ExternalPilot>>(fileName);

        if (!pilotsFromFileResult.IsSuccess)
        {
            _logger.LogWarning("Can not get pilots from json");
            return;
        }

        if (pilotsFromFileResult.Content?.Any() != true)
        {
            _logger.LogWarning("No pilots to import");
            return;
        }

        //mappare dati su entità

        var pilotsToInsert = pilotsFromFileResult.Content.Select(x => new Pilot()
        {
            FirstName = x.FirstName,
            LastName = x.LastName,
            Dob = x.Dob,
            HoursFlown = x.HoursFlown,
            PilotId = x.PilotId,
            PlaneModels = x.PlaneModels.Select(m => new PlaneModel()
            {
                ModelNumber = m.PlaneModel,
            }).ToList()
        }).ToList();

        //salvare dati tramite repository
        _pilotsRepository.Insert(pilotsToInsert);
        _logger.LogInformation("Import complete");
    }

    public void Query()
    {
        _pilotsRepository.Query();
    }
}
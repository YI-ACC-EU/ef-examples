using AirportExample.Repositories;
namespace AirportExample.Services;

public interface IMainService
{
    public void Run();
}
public class MainService : IMainService
{
    private  IAirportService _airportsService;
    private IPilotService _pilotService;

    public MainService(IAirportService airportsService, IPilotService pilotService)
    {
        _airportsService = airportsService;
        _pilotService = pilotService;
    }

    public void Run()
    {
        //Qui mettiamo la logica dell'app
        //throw new NotImplementedException();
        //_airportsService.PrintByCountryCode("ITA");

        //_pilotService.ImportPilots();

        _pilotService.Query();
    }
}
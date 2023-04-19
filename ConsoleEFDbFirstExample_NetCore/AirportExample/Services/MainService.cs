using AirportExample.Repositories;
namespace AirportExample.Services;

public interface IMainService
{
    public void Run();
}
public class MainService : IMainService
{
    private  IAirportService _airportsService;

    public MainService(IAirportService airportsService)
    {
        _airportsService = airportsService;
    }

    public void Run()
    {
        _airportsService.PrintByCountryCode("ITA");
        //Qui mettiamo la logica dell'app
        //throw new NotImplementedException();
    }
}
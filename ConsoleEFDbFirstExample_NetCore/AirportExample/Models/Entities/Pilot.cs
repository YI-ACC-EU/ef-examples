namespace AirportExample.Models.Entities;

public class Pilot
{
    public int PilotId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public short HoursFlown { get; set; }

    public virtual List<FlightInstance> FlightInstanceCoPilotAboards { get; set; } = new();

    public virtual List<FlightInstance> FlightInstancePilotAboards { get; set; } = new();

    public virtual List<PlaneModel> PlaneModels { get; set; } = new();
}

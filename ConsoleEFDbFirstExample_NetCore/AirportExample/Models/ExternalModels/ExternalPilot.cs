namespace AirportExample.Models.Dto;
public class ExternalPilot
{
    public int PilotId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Dob { get; set; }
    public short HoursFlown { get; set; }
    public List<ExternalPlaneModel> PlaneModels { get; set; }
}

public class ExternalPlaneModel
{
    public string PlaneModel { get; set; }
}
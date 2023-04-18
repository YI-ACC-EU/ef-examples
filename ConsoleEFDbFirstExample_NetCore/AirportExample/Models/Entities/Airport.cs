namespace AirportExample.Models.Entities;

public class Airport
{
    public string AirportCode { get; set; } = null!;

    public string AirportName { get; set; } = null!;

    public decimal ContactNo { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string CountryCode { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual List<Flight> FlightArriveFrom { get; set; } = new();

    public virtual List<Flight> FlightDepartTo { get; set; } = new();
}

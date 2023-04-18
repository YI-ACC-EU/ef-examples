namespace AirportExample.Models.Entities;

public class Flight
{
    public string FlightNo { get; set; } = null!;

    public string FlightDepartToId { get; set; } = null!;

    public string FlightArriveFromId { get; set; } = null!;

    public int Distance { get; set; }

    public virtual Airport ArriveFrom { get; set; } = null!;

    public virtual Airport DepartTo { get; set; } = null!;

    public virtual List<FlightInstance> FlightInstances { get; set; } = new();
}

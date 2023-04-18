namespace AirportExample.Models.Entities;

public class PlaneModel
{
    public string ModelNumber { get; set; } = null!;

    public string ManufacturerName { get; set; } = null!;

    public short PlaneRange { get; set; }

    public short CruiseSpeed { get; set; }

    public virtual List<PlaneDetail> PlaneDetails { get; set; } = new ();

    public virtual List<Pilot> Pilots { get; set; } = new ();
}

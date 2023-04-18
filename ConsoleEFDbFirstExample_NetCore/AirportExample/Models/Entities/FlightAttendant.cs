namespace AirportExample.Models.Entities;

public class FlightAttendant
{
    public int AttendantId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public DateTime HireDate { get; set; }

    public int? MentorId { get; set; }

    public virtual List<FlightInstance> FlightInstances { get; set; } = new();

    public virtual List<FlightAttendant> InverseMentor { get; set; } = new();

    public virtual FlightAttendant? Mentor { get; set; }

    public virtual List<FlightInstance> Instances { get; set; } = new();
}

namespace Euris.Aeroporti.ScaffoldExample.Models.DB;
public class Pilot
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public virtual List<Volo> Flights { get; set; }
}
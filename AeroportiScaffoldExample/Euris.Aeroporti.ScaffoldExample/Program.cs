using Euris.Aeroporti.ScaffoldExample.Models.DB;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
using var db = new AeroportiContext();

if (!db.Pilots.Any())
{
    db.Pilots.Add(new Pilot() {Id = "P1", Name = "Mario", Surname = "Rossi"});
    db.SaveChanges();
}
Console.WriteLine("");
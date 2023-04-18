using AirportExample.Models.Entities;
using AirportExample.Repositories.DbContexts.Configurations;
using Microsoft.EntityFrameworkCore;
namespace AirportExample.Repositories.DbContexts;

public  class AirlinesDbContext : DbContext
{

    public AirlinesDbContext() { }

    public AirlinesDbContext(DbContextOptions<AirlinesDbContext> options)
        : base(options) { }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightAttendant> FlightAttendants { get; set; }

    public virtual DbSet<FlightInstance> FlightInstances { get; set; }

    public virtual DbSet<Pilot> Pilots { get; set; }

    public virtual DbSet<PlaneDetail> PlaneDetails { get; set; }

    public virtual DbSet<PlaneModel> PlaneModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AirportConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new FlightAttendantConfiguration());
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        modelBuilder.ApplyConfiguration(new FlightInstanceConfiguration());
        modelBuilder.ApplyConfiguration(new PilotConfiguration());
        modelBuilder.ApplyConfiguration(new PlaneDetailConfiguration());
        modelBuilder.ApplyConfiguration(new PlaneModelConfiguration());
    }

}

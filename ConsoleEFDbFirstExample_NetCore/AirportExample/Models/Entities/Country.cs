using System;
using System.Collections.Generic;

namespace AirportExample.Models.Entities;

public partial class Country
{
    public string CountryName { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public virtual List<Airport> Airports { get; set; } = new();
}

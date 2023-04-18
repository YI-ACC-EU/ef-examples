using System;
using System.Collections.Generic;

namespace Euris.Aeroporti.ScaffoldExample.Models.DB;

public partial class Volo
{
    public string IdVolo { get; set; } = null!;

    public string GiornoSett { get; set; } = null!;

    public string CittaPart { get; set; } = null!;

    public TimeSpan OraPart { get; set; }

    public string CittaArr { get; set; } = null!;

    public TimeSpan OraArr { get; set; }

    public string TipoAereo { get; set; } = null!;

    public virtual Aeroporto CittaArrNavigation { get; set; } = null!;

    public virtual Aeroporto CittaPartNavigation { get; set; } = null!;

    public virtual Plains TipoPlainsNavigation { get; set; } = null!;

    public virtual List<Pilot> PilotsNavigation { get; set; } = null!;
}

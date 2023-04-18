using System;
using System.Collections.Generic;

namespace Euris.Aeroporti.ScaffoldExample.Models.DB;

public partial class Aeroporto
{
    public string Citta { get; set; } = null!;

    public string Nazione { get; set; } = null!;

    public int? NumPiste { get; set; }

    public virtual ICollection<Volo> VoloCittaArrNavigations { get; set; } = new List<Volo>();

    public virtual ICollection<Volo> VoloCittaPartNavigations { get; set; } = new List<Volo>();
}

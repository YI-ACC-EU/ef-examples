using System;
using System.Collections.Generic;

namespace Euris.Aeroporti.ScaffoldExample.Models.DB;

public partial class Plains
{
    public string PlainType { get; set; } = null!;

    public int PassengersNumber { get; set; }

    public int GoodsQuantity { get; set; }

    public virtual ICollection<Volo> Flights { get; set; } = new List<Volo>();
}

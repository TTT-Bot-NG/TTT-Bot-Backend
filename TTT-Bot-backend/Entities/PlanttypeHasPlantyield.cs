using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class PlanttypeHasPlantyield
{
    public int PlantTypeId { get; set; }

    public int PlantYieldId { get; set; }

    public virtual Planttype PlantType { get; set; } = null!;
}

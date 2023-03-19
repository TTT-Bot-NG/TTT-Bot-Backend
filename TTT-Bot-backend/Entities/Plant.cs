using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Plant
{
    public int Id { get; set; }

    public DateTime? PlantedTime { get; set; }

    public int PlantTypeId { get; set; }

    public virtual Planttype PlantType { get; set; } = null!;
}

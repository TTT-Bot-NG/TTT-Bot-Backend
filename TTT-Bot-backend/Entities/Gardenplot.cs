using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Gardenplot
{
    public int Id { get; set; }

    public int PlantId { get; set; }

    public sbyte IsLocked { get; set; }
}

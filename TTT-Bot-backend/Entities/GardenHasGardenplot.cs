using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class GardenHasGardenplot
{
    public int GardenId { get; set; }

    public int GardenPlotId { get; set; }

    public virtual Garden Garden { get; set; } = null!;
}

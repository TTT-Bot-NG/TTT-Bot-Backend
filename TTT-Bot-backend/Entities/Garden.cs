using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Garden
{
    public int Id { get; set; }

    public virtual ICollection<GardenHasGardenplot> GardenHasGardenplots { get; } = new List<GardenHasGardenplot>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}

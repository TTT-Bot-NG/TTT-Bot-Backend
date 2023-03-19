using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Xpboost
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Multiplier { get; set; }

    public TimeOnly Duration { get; set; }

    public virtual ICollection<Activexpboost> Activexpboosts { get; } = new List<Activexpboost>();
}

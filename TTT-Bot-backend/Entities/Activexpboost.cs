using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Activexpboost
{
    public int Id { get; set; }

    public DateTime EndTime { get; set; }

    public int XpBoostId { get; set; }

    public virtual Xpboost XpBoost { get; set; } = null!;
}

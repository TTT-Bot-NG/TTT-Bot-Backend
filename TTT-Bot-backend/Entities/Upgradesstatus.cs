using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Upgradesstatus
{
    public int Id { get; set; }

    public sbyte XpBoostSlot2 { get; set; }

    public int MultiChance2 { get; set; }

    public int MultiChance4 { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}

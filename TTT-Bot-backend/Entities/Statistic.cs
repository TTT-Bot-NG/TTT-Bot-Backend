using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Statistic
{
    public int Id { get; set; }

    public int MaxDailyStreak { get; set; }

    public int MaxWeeklyStreak { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}

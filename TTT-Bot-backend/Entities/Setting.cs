using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Setting
{
    public int Id { get; set; }

    public sbyte PrivateLevelUpNotifications { get; set; }

    public sbyte DailyNotifications { get; set; }

    public sbyte WeeklyNotifications { get; set; }

    public sbyte HoroscopeNotifications { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}

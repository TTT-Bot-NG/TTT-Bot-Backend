using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class User
{
    public int Id { get; set; }

    public long? ExtraIdentifier { get; set; }

    public double Xp { get; set; }

    public long? ActionCooldown { get; set; }

    public int? XpBoostMax { get; set; }

    public int Currency { get; set; }

    public int SettingsId { get; set; }

    public long? Upvotes { get; set; }

    public int? UpvoteInterval { get; set; }

    public DateTime? LastDailyClaim { get; set; }

    public DateTime? LastWeeklyClaim { get; set; }

    public int? DailyStreak { get; set; }

    public int? WeeklyStreak { get; set; }

    public int StatisticsId { get; set; }

    public int InventoryId { get; set; }

    public int UpgradesStatusId { get; set; }

    public int GardenId { get; set; }

    public int AvtivePokemonId { get; set; }

    public virtual Garden Garden { get; set; } = null!;

    public virtual Inventory Inventory { get; set; } = null!;

    public virtual Setting Settings { get; set; } = null!;

    public virtual Statistic Statistics { get; set; } = null!;

    public virtual Upgradesstatus UpgradesStatus { get; set; } = null!;
}

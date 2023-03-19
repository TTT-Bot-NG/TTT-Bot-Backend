using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Notification
{
    public long Id { get; set; }

    public string Message { get; set; } = null!;

    public DateTime NotifyTime { get; set; }

    public virtual ICollection<NotificationsHasUser> NotificationsHasUsers { get; } = new List<NotificationsHasUser>();
}

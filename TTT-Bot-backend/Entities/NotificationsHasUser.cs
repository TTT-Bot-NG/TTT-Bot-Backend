using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class NotificationsHasUser
{
    public long NotificationsId { get; set; }

    public int UserId { get; set; }

    public virtual Notification Notifications { get; set; } = null!;
}

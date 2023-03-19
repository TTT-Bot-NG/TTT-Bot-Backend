using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class GuildHasUserHasRole
{
    public int GuildHasUserUserId { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}

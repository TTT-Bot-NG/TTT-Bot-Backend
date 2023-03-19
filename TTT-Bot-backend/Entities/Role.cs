using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Role
{
    public int Id { get; set; }

    public long? ExtraIdentifier { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GuildHasUserHasRole> GuildHasUserHasRoles { get; } = new List<GuildHasUserHasRole>();
}

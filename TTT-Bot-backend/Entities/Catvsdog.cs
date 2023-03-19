using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Catvsdog
{
    public int Id { get; set; }

    public int Cat { get; set; }

    public int Dog { get; set; }

    public virtual ICollection<Guild> Guilds { get; } = new List<Guild>();
}

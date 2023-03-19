using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class GuildHasUser
{
    public int GuildId { get; set; }

    public int UserId { get; set; }

    public string? NickName { get; set; }
}

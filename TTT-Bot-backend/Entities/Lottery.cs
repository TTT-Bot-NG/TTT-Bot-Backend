using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Lottery
{
    public long Id { get; set; }

    public DateTime EndTime { get; set; }

    public virtual ICollection<Guild> Guilds { get; } = new List<Guild>();

    public virtual ICollection<LotteryHasLotteryparticipant> LotteryHasLotteryparticipants { get; } = new List<LotteryHasLotteryparticipant>();
}

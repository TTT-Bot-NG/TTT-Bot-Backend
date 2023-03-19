using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class LotteryHasLotteryparticipant
{
    public long LotteryId { get; set; }

    public int LotteryParticipantId { get; set; }

    public virtual Lottery Lottery { get; set; } = null!;
}

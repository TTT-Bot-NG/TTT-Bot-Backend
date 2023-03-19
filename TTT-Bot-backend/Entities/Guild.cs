using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Guild
{
    public int Id { get; set; }

    public long? ExtraIdentifier { get; set; }

    public int CatVsDogId { get; set; }

    public long LotteryId { get; set; }

    public virtual Catvsdog CatVsDog { get; set; } = null!;

    public virtual Lottery Lottery { get; set; } = null!;
}

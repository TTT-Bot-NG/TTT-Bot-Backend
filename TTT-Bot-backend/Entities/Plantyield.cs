using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Plantyield
{
    public int Id { get; set; }

    public int MinAmount { get; set; }

    public int MaxAmount { get; set; }

    public int ItemId { get; set; }

    public virtual Item Item { get; set; } = null!;
}

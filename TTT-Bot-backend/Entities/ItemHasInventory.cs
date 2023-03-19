using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class ItemHasInventory
{
    public int ItemId { get; set; }

    public int InventoryId { get; set; }

    public int Count { get; set; }

    public virtual Inventory Inventory { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}

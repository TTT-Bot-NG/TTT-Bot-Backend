using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ItemHasInventory> ItemHasInventories { get; } = new List<ItemHasInventory>();

    public virtual ICollection<Plantyield> Plantyields { get; } = new List<Plantyield>();
}

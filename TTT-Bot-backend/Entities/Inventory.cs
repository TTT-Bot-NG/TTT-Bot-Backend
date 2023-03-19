using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Inventory
{
    public int Id { get; set; }

    public virtual ICollection<ItemHasInventory> ItemHasInventories { get; } = new List<ItemHasInventory>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}

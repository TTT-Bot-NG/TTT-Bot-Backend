using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class UserHasPokemon
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PokemonId { get; set; }
}

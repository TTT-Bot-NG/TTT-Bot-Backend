using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class PokemontypeIsWeakAgainstPokemontype
{
    public int PokemonTypeId { get; set; }

    public int WeakAgainstPokemonTypeId { get; set; }

    public double DamageMultiplier { get; set; }

    public virtual Pokemontype PokemonType { get; set; } = null!;

    public virtual Pokemontype WeakAgainstPokemonType { get; set; } = null!;
}

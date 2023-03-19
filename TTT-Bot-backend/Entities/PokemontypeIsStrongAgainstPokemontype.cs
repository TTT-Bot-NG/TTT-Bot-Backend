using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class PokemontypeIsStrongAgainstPokemontype
{
    public int PokemonTypeId { get; set; }

    public int StrongAgainstPokemonTypeId { get; set; }

    public double DamageMultiplier { get; set; }

    public virtual Pokemontype PokemonType { get; set; } = null!;

    public virtual Pokemontype StrongAgainstPokemonType { get; set; } = null!;
}

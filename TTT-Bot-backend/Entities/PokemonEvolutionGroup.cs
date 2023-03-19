using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class PokemonEvolutionGroup
{
    public int Id { get; set; }

    public virtual ICollection<PokemonEvolutionGroupHasPokemonEvolution> PokemonEvolutionGroupHasPokemonEvolutions { get; } = new List<PokemonEvolutionGroupHasPokemonEvolution>();

    public virtual ICollection<Pokemon> Pokemons { get; } = new List<Pokemon>();
}

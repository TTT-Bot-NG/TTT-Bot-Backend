using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class PokemonEvolutionGroupHasPokemonEvolution
{
    public int PokemonEvolutionGroupId { get; set; }

    public int PokemonEvolutionPokedexId { get; set; }

    public int CurrentEvolution { get; set; }

    public virtual PokemonEvolutionGroup PokemonEvolutionGroup { get; set; } = null!;

    public virtual PokemonEvolution PokemonEvolutionPokedex { get; set; } = null!;
}

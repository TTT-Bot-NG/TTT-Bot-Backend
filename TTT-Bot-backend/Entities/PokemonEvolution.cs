using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class PokemonEvolution
{
    public int PokedexId { get; set; }

    public string Name { get; set; } = null!;

    public int BaseHp { get; set; }

    public int BaseAttack { get; set; }

    public int BaseDefense { get; set; }

    public int BaseSpAttack { get; set; }

    public int BaseSpDefense { get; set; }

    public virtual ICollection<PokemonEvolutionGroupHasPokemonEvolution> PokemonEvolutionGroupHasPokemonEvolutions { get; } = new List<PokemonEvolutionGroupHasPokemonEvolution>();

    public virtual ICollection<Pokemontype> PokemonTypes { get; } = new List<Pokemontype>();
}

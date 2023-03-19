using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Pokemontype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<PokemontypeIsStrongAgainstPokemontype> PokemontypeIsStrongAgainstPokemontypePokemonTypes { get; } = new List<PokemontypeIsStrongAgainstPokemontype>();

    public virtual ICollection<PokemontypeIsStrongAgainstPokemontype> PokemontypeIsStrongAgainstPokemontypeStrongAgainstPokemonTypes { get; } = new List<PokemontypeIsStrongAgainstPokemontype>();

    public virtual ICollection<PokemontypeIsWeakAgainstPokemontype> PokemontypeIsWeakAgainstPokemontypePokemonTypes { get; } = new List<PokemontypeIsWeakAgainstPokemontype>();

    public virtual ICollection<PokemontypeIsWeakAgainstPokemontype> PokemontypeIsWeakAgainstPokemontypeWeakAgainstPokemonTypes { get; } = new List<PokemontypeIsWeakAgainstPokemontype>();

    public virtual ICollection<PokemonEvolution> PokemonPokedices { get; } = new List<PokemonEvolution>();
}

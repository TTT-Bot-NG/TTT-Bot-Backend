using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Pokemon
{
    public int Id { get; set; }

    public int PokemonEvolutionGroupId { get; set; }

    public int CurrentEvolution { get; set; }

    public double Xp { get; set; }

    public DateTime? CooldownEndTime { get; set; }

    public double CurrentHp { get; set; }

    public double MaxHp { get; set; }

    public double Attack { get; set; }

    public double Defense { get; set; }

    public double SpAttack { get; set; }

    public double SpDefense { get; set; }

    public double Speed { get; set; }

    public int HpIv { get; set; }

    public int AttackIv { get; set; }

    public int DefenseIv { get; set; }

    public int SpAttackIv { get; set; }

    public int SpDefenseIv { get; set; }

    public int SpeedIv { get; set; }

    public virtual PokemonEvolutionGroup PokemonEvolutionGroup { get; set; } = null!;
}

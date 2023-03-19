using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Planttype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public TimeOnly TimeToGrow { get; set; }

    public virtual ICollection<Plant> Plants { get; } = new List<Plant>();

    public virtual ICollection<PlanttypeHasPlantyield> PlanttypeHasPlantyields { get; } = new List<PlanttypeHasPlantyield>();
}

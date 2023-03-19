using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class UserHasPokemonFightRequest
{
    public int UserHasPokemonId { get; set; }

    public int ChallengedUserHasPokemonId { get; set; }

    public sbyte? IsAccepted { get; set; }

    public sbyte? ChallengerIsWinner { get; set; }
}

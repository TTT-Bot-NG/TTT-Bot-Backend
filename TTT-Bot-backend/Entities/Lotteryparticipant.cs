using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Lotteryparticipant
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Tickets { get; set; }
}

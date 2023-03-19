using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class UserMarriageProposal
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public int ProposalMadeToUserId { get; set; }

    public sbyte? IsAccepted { get; set; }
}

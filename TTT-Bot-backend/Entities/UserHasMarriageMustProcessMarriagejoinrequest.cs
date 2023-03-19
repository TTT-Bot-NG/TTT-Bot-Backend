using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class UserHasMarriageMustProcessMarriagejoinrequest
{
    public int MarriageHasMarriageJoinRequestId { get; set; }

    public int UserHasMarriageUserId { get; set; }

    public sbyte? IsAccepted { get; set; }
}

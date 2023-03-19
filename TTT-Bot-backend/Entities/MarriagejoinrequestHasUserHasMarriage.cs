using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class MarriagejoinrequestHasUserHasMarriage
{
    public long MarriageJoinRequestId { get; set; }

    public int UserHasMarriageUserId { get; set; }

    public int UserHasMarriageMarriageId { get; set; }

    public virtual UserHasMarriage UserHasMarriage { get; set; } = null!;
}

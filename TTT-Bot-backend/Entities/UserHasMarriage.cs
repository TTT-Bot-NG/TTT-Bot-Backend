using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class UserHasMarriage
{
    public int UserId { get; set; }

    public int MarriageId { get; set; }

    public DateTime? JoinTime { get; set; }

    public virtual Marriage Marriage { get; set; } = null!;

    public virtual ICollection<MarriagejoinrequestHasUserHasMarriage> MarriagejoinrequestHasUserHasMarriages { get; } = new List<MarriagejoinrequestHasUserHasMarriage>();
}

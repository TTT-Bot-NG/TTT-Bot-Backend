using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Marriage
{
    public int Id { get; set; }

    public DateTime? StartTime { get; set; }

    public virtual ICollection<Marriagejoinrequest> Marriagejoinrequests { get; } = new List<Marriagejoinrequest>();

    public virtual ICollection<UserHasMarriage> UserHasMarriages { get; } = new List<UserHasMarriage>();
}

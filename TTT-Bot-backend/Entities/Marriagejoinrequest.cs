using System;
using System.Collections.Generic;

namespace TTT_Bot_backend.Entities;

public partial class Marriagejoinrequest
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public int MarriageId { get; set; }

    public virtual Marriage Marriage { get; set; } = null!;
}

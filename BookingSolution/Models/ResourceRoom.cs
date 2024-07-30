using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class ResourceRoom
{
    public int RoomId { get; set; }

    public int ResourceId { get; set; }

    public bool? Status { get; set; }

    public virtual MstResource Resource { get; set; } = null!;

    public virtual MstRoom Room { get; set; } = null!;
}

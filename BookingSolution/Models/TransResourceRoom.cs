using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class TransResourceRoom
{
    public int Id { get; set; }

    public int? RoomId { get; set; }

    public int? ResourceCodeId { get; set; }

    public bool? IsExpired { get; set; }

    public virtual MstResourceCode? ResourceCode { get; set; }

    public virtual MstRoom? Room { get; set; }
}

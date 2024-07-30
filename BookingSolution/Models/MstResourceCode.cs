using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class MstResourceCode
{
    public int Id { get; set; }

    public string ResourceCode { get; set; } = null!;

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? ResourceId { get; set; }

    public virtual MstResource? Resource { get; set; }

    public virtual ICollection<TransResourceRoom> TransResourceRooms { get; set; } = new List<TransResourceRoom>();
}

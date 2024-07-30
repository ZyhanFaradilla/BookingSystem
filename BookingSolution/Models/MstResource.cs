using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class MstResource
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public string? Icon { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public virtual ICollection<MstResourceCode> MstResourceCodes { get; set; } = new List<MstResourceCode>();

    public virtual ICollection<ResourceRoom> ResourceRooms { get; set; } = new List<ResourceRoom>();
}

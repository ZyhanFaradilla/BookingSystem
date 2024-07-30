using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class MstRoom
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Floor { get; set; }

    public int Capacity { get; set; }

    public string? Description { get; set; }

    public string? Color { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public int? LocationId { get; set; }

    public virtual MstLocation? Location { get; set; }

    public virtual ICollection<ResourceRoom> ResourceRooms { get; set; } = new List<ResourceRoom>();

    public virtual ICollection<TransResourceRoom> TransResourceRooms { get; set; } = new List<TransResourceRoom>();
}

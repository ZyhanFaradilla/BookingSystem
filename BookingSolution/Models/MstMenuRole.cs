using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class MstMenuRole
{
    public int Id { get; set; }

    public int? MenuId { get; set; }

    public int? RoleId { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual MstMenu? Menu { get; set; }

    public virtual MstRole? Role { get; set; }
}

using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class MstRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpadatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public virtual ICollection<MstMenuRole> MstMenuRoles { get; set; } = new List<MstMenuRole>();

    public virtual ICollection<MstUser> MstUsers { get; set; } = new List<MstUser>();
}

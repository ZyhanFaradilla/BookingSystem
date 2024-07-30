using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class MstMenu
{
    public int Id { get; set; }

    public string MenuName { get; set; } = null!;

    public string Function { get; set; } = null!;

    public int Sequence { get; set; }

    public bool IsHeader { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpadatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<MstMenuRole> MstMenuRoles { get; set; } = new List<MstMenuRole>();
}

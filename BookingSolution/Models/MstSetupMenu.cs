using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class MstSetupMenu
{
    public string ParameterCode { get; set; } = null!;

    public string ParameterName { get; set; } = null!;

    public string? ParameterDescription { get; set; }

    public string? ParameterValue { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }
}

using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class TransCatering
{
    public int Id { get; set; }

    public string Item { get; set; } = null!;

    public int? HistoryId { get; set; }

    public int? Quantity { get; set; }

    public string? Notes { get; set; }

    public string? Status { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

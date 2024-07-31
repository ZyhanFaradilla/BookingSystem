using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class TransResourceHistory
{
    public int Id { get; set; }

    public int? ResourceRoomId { get; set; }

    public string? RequestBy { get; set; }

    public DateTimeOffset? TimeFrom { get; set; }

    public DateTimeOffset? TimeTo { get; set; }

    public DateOnly? Date { get; set; }

    public string? Status { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TransResourceRoom? ResourceRoom { get; set; }
}

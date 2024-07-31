using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class TransHistory
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public string? Necessity { get; set; }

    public string? RequestBy { get; set; }

    public DateTimeOffset? TimeFrom { get; set; }

    public DateTimeOffset? TimeTo { get; set; }

    public DateOnly? Date { get; set; }

    public string? Email { get; set; }

    public string? CancelledBy { get; set; }

    public DateTime? CancelledDate { get; set; }

    public string? Status { get; set; }

    public bool? IsAllDay { get; set; }

    public bool? IsVip { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual MstRoom Room { get; set; } = null!;

    public virtual ICollection<TransParticipantHist> TransParticipantHists { get; set; } = new List<TransParticipantHist>();
}

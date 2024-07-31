using System;
using System.Collections.Generic;

namespace Booking.DataAccess.Models;

public partial class TransParticipantHist
{
    public int Id { get; set; }

    public int HistoryId { get; set; }

    public string? Email { get; set; }

    public virtual TransHistory History { get; set; } = null!;
}

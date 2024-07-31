using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Transaction.TransHistory
{
    public class CreatedTransHistoryDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RequestBy { get; set; }
        public string RequestEmail { get; set; }
        public bool IsVIP { get; set; }
        public List<int> Participants { get; set; } = new List<int>();
        public string Necessity { get; set; }
        public string Routine { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeTo { get; set; }
        public List<int> Resources { get; set; } = new List<int>();
        public bool IsAllDay { get; set; }
    }
}

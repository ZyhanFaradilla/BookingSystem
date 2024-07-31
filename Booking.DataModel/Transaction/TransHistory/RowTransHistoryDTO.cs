using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Transaction.TransHistory
{
    public class RowTransHistoryDTO
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string Necessity { get; set; }
        public string RequestBy {  get; set; }
        public DateOnly Date {  get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
        public string Email { get; set; }
        public bool IsAllDay { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CancelledBy { get; set; }
        public DateTime CancelledDate { get; set; }
        public string Status { get; set; }
    }
}

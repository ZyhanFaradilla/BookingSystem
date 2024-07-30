using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Master.BookingCode
{
    public class CreatedBookingCodeDTO
    {
        public int Id { get; set; }
        public string BookingCode { get; set; }
        public bool Status { get; set; }
    }
}

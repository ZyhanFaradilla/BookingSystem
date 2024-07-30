using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Master.BookingCode
{
    public class IndexBookingCodeDTO
    {
        public List<RowBookingCodeDTO>? RowBookingCode { get; set; } = new List<RowBookingCodeDTO>();
        public int TotalPages { get; set; } 
    }
}

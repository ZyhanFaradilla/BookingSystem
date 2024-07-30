using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Master.Room
{
    public class IndexRoomDTO
    {
        public List<RowRoomDTO> RowRooms { get; set; } = new List<RowRoomDTO>();
        public int TotalPages { get; set; }
    }
}

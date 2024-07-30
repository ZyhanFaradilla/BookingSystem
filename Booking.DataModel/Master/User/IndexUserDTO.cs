using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Master.User
{
    public class IndexUserDTO
    {
        public List<RowUserDTO> RowUsers { get; set; } = new List<RowUserDTO>();
        public int TotalPages { get; set; }

    }
}

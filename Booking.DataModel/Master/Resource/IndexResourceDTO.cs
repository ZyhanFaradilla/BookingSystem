using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Master.Resource
{
    public class IndexResourceDTO
    {
        public List<RowResourceDTO> RowResources { get; set; } = new List<RowResourceDTO>();
        public int TotalPages { get; set; }
    }
}

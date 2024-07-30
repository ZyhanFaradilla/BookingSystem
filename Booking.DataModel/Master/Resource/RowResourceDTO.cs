using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Master.Resource
{
    public class RowResourceDTO
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public bool Status { get; set; }
        public string Icon { get; set; }
    }
}

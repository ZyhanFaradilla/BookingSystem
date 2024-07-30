using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Master.GlobalSetup
{
    public class IndexGlobalSetupDTO
    {
        public List<RowGlobalSetupDTO> RowGlobalSetup { get; set; } = new List<RowGlobalSetupDTO>();
        public int TotalPages { get; set; }
    }
}

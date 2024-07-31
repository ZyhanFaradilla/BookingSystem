using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Transaction.TransHistory
{
    public class IndexTransHistoryDTO
    {
        public List<RowTransHistoryDTO> RowTransHistory { get; set; } = new List<RowTransHistoryDTO>();
        public int TotalPages { get; set; }
    }
}

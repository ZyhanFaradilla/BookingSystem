using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Master.Role
{
    public class IndexRoleDTO
    {
        public List<RowRoleDTO> Roles { get; set; } = new List<RowRoleDTO>();
        public int TotalPages { get; set; }
    }
}

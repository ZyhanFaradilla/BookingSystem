using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.DataModel.Utility;

namespace Booking.DataModel.Master.User
{
    public class CreatedUserDTO
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<DropdownDTO>? RoleDropdown { get; set; }
    }
}

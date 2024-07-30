using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.DataModel.Utility;

namespace Booking.DataModel.Master.Room
{
    public class CreatedRoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor {  get; set; }
        public string Description { get; set; }
        public int? LocationId { get; set; }
        public IEnumerable<DropdownDTO>? LocationDropdown { get; set; }
        public List<int>? Resources { get; set; } = new List<int>();
        public List<CheckboxDTO>? ResourcesCheckbox { get; set; }
        public int Capacity { get; set; }
        public string ColorRoom { get; set; }
    }
}

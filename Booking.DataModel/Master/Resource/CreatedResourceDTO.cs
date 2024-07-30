using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.DataModel.Master.ResourceCode;

namespace Booking.DataModel.Master.Resource
{
    public class CreatedResourceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ResourceCodeDTO>? Codes { get; set; } = new List<ResourceCodeDTO>();
        public bool Status { get; set; }
        public string? ResourceIcon { get; set; }
        public string? FileNameOnServer { get; set; }
    }
}

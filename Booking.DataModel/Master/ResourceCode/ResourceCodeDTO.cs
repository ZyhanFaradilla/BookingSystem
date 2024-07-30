using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataModel.Master.ResourceCode
{
    public class ResourceCodeDTO
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string ResourceCode { get; set; }
        public int? ResourceId { get; set; }
    }
}

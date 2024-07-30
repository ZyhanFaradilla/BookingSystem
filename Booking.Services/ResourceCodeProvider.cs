using Booking.DataAccess.Models;
using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.Resource;
using Booking.DataModel.Master.ResourceCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class ResourceCodeProvider
    {
        private BookingContext context;

        public ResourceCodeProvider(BookingContext booking)
        {
            this.context = booking;
        }

        public IndexResourceCodeDTO AllResourceCode()
        {
            var dto = new IndexResourceCodeDTO();
            using (var dbContext = new BookingContext())
            {
                var query = from resCode in dbContext.MstResourceCodes
                            where !resCode.DeletedDate.HasValue
                            orderby resCode.Id
                            select new ResourceCodeDTO
                            {
                                Id = resCode.Id,
                                ResourceCode = resCode.ResourceCode,
                                Status = resCode.IsActive,
                                ResourceId = resCode.ResourceId
                            };
                dto.ResourceCodes = query.ToList();
            }
            return dto;
        }

        public void InserResourceCode(ResourceCodeDTO model)
        {
            var newData = new MstResourceCode();
            newData.ResourceCode = model.ResourceCode;
            newData.IsActive = model.Status;
            newData.ResourceId = model.ResourceId;
            newData.CreatedDate = DateTime.UtcNow;
            newData.CreatedBy = 1;
            context.MstResourceCodes.Add(newData);
            context.SaveChanges();
        }

        public MstResourceCode GetResourceCode(int id)
        {
            return context.MstResourceCodes.SingleOrDefault(resCode => resCode.Id == id);
        }

        public void UpdateResourceCode(ResourceCodeDTO model)
        {
            var getData = GetResourceCode(model.Id);
            getData.ResourceCode = model.ResourceCode;
            getData.IsActive = model.Status;
            getData.ResourceId = model.ResourceId;
            getData.UpdatedDate = DateTime.UtcNow;
            getData.UpdatedBy = 1;
            context.SaveChanges();
        }

        public void DeleteResourceCode(int id)
        {
            var getData = GetResourceCode(id);
            getData.DeletedDate = DateTime.UtcNow;
            getData.DeletedBy = 1;
            context.SaveChanges();
        }
    }
}

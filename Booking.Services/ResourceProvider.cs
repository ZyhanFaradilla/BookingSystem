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
    public class ResourceProvider : BasicService
    {
        private BookingContext context;

        public ResourceProvider(BookingContext booking)
        {
            this.context = booking;
        }

        public IndexResourceDTO AllResource(int page)
        {
            var dto = new IndexResourceDTO();
            using (var dbContext = new BookingContext())
            {
                var query = from resource in dbContext.MstResources
                            where !resource.DeletedDate.HasValue
                            orderby resource.Id
                            select new RowResourceDTO
                            {
                                Id = resource.Id,
                                ResourceName = resource.Name,
                                Status = resource.Status,
                                Icon = resource.Icon
                            };
                var totalData = GetTotalPage(query.Count());
                query = query.Skip(GetSkip(page)).Take(10);
                dto.RowResources = query.ToList();
                dto.TotalPages = totalData;
            }
            return dto;
        }

        public void InsertResource(CreatedResourceDTO model)
        {
            var newData = new MstResource();
            newData.Name = model.Name;
            newData.Status = model.Status;
            newData.Icon = model.ResourceIcon;
            newData.CreatedDate = DateTime.UtcNow;
            newData.CreatedBy = 1;
            context.MstResources.Add(newData);
            context.SaveChanges();
        }

        public MstResource GetResource(int id)
        {
            return context.MstResources.SingleOrDefault(resource => resource.Id == id);
        }

        public void UpdateResource(CreatedResourceDTO model)
        {
            var getData = GetResource(model.Id);
            getData.Name = model.Name;
            getData.Status = model.Status;
            getData.Icon = model.ResourceIcon;
            getData.UpdatedDate = DateTime.UtcNow;
            getData.UpdatedBy = 1;
            context.SaveChanges();
        }

        public void DeleteResource(int id)
        {
            var getData = GetResource(id);
            var resourceCode = context.MstResourceCodes.Where(resCode => resCode.ResourceId == id).ToList();
            if (resourceCode.Count > 0)
            {
                foreach (var resource in resourceCode)
                {
                    resource.DeletedDate = DateTime.UtcNow;
                    resource.DeletedBy = 1;
                    resource.IsActive = false;
                }
            }
            getData.DeletedDate = DateTime.UtcNow;
            getData.DeletedBy = 1;
            context.SaveChanges();
        }
    }
}

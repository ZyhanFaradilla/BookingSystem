using Booking.DataAccess.Models;
using Booking.DataModel.Master;
using Booking.DataModel.Master.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class LocationProvider
    {
        private BookingContext context;

        public LocationProvider(BookingContext booking)
        {
            this.context = booking;
        }

        public void InsertLoaction(CreatedLocation model)
        {
            var newData = new MstLocation();
            newData.Name = model.Name;
            newData.CreatedDate = DateTime.UtcNow;
            newData.CreatedBy = 1;
            context.MstLocations.Add(newData);
            context.SaveChanges();
        }

        public MstLocation GetLocation(int id)
        {
            return context.MstLocations.SingleOrDefault(location => location.Id == id);
        }

        public void UpdateLocation(CreatedLocation model)
        {
            var getData = GetLocation(model.Id);
            getData.Name = model.Name;
            getData.UpdatedDate = DateTime.UtcNow;
            getData.UpdatedBy = 1;
            context.SaveChanges();
        }

        public void DeleteLocation(int id)
        {
            var getData = GetLocation(id);
            getData.DeletedDate = DateTime.UtcNow;
            getData.DeletedBy = 1;
            context.SaveChanges();
        }
    }
}

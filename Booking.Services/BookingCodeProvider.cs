using Booking.DataAccess.Models;
using Booking.DataModel.Master.BookingCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Booking.Services
{
    public class BookingCodeProvider : BasicService
    {
        private BookingContext context;

        public BookingCodeProvider(BookingContext booking)
        {
            this.context = booking;
        }

        public IndexBookingCodeDTO AllBookingCode(int page)
        {
            var dto = new IndexBookingCodeDTO();
            using (var dbContext = new BookingContext())
            {
                var query = from bookingCode in dbContext.MstBookingCodes
                            where !bookingCode.DeletedDate.HasValue orderby bookingCode.Id
                            select new RowBookingCodeDTO
                            {
                                Id = bookingCode.Id,
                                BookingCode = bookingCode.BookingCode
                            };
                var totalData = GetTotalPage(query.Count());
                query = query.Skip(GetSkip(page)).Take(10);
                dto.RowBookingCode = query.ToList();
                dto.TotalPages = totalData;
            }
            return dto;
        }

        public void InsertBookingCode(CreatedBookingCodeDTO model)
        {
            var newData = new MstBookingCode();
            newData.BookingCode = model.BookingCode;
            newData.Status = model.Status;
            newData.CreatedDate = DateTime.UtcNow;
            newData.CreatedBy = 1;
            context.MstBookingCodes.Add(newData);
            context.SaveChanges();
        }

        public MstBookingCode GetBookingCode(int id)
        {
            return context.MstBookingCodes.SingleOrDefault(bookingCode => bookingCode.Id == id);
        }

        public void UpdateBookingCode(CreatedBookingCodeDTO model)
        {
            var getData = GetBookingCode(model.Id);
            getData.BookingCode = model.BookingCode;
            getData.Status = model.Status;
            getData.UpdatedDate = DateTime.UtcNow;
            getData.UpdatedBy = 1;
            context.SaveChanges();
        }

        public void DeleteBookingCode(int id)
        {
            var getData = GetBookingCode(id);
            getData.DeletedDate = DateTime.UtcNow;
            getData.DeletedBy = 1;
            context.SaveChanges();
        }
    }
}

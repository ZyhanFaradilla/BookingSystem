using Booking.DataAccess.Models;
using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Transaction.TransHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class HistoryBookingProvider : BasicService
    {
        private BookingContext context;

        public HistoryBookingProvider(BookingContext booking)
        {
            this.context = booking;
        }

        public IndexTransHistoryDTO AllHistoryBooking(int page)
        {
            var dto = new IndexTransHistoryDTO();
            using (var dbContext = new BookingContext())
            {
                var query = from history in dbContext.TransHistories
                            orderby history.Id
                            select new RowTransHistoryDTO
                            {
                                Id = history.Id,
                                RoomName = GetRoomName(history.RoomId),
                                Necessity = history.Necessity,
                                RequestBy = history.RequestBy,
                                Date = history.Date.Value,
                                From = history.TimeFrom.Value,
                                To = history.TimeTo.Value,
                                Email = history.Email,
                                IsAllDay = history.IsAllDay.Value,
                                CreatedBy = history.CreatedBy.ToString(),
                                CreatedDate = history.CreatedDate,
                                CancelledBy = history.CancelledBy,
                                CancelledDate = history.CancelledDate.Value,
                                Status = history.Status
                            };
                var totalData = GetTotalPage(query.Count());
                query = query.Skip(GetSkip(page)).Take(10);
                dto.RowTransHistory = query.ToList();
                dto.TotalPages = totalData;
            }
            return dto;
        }
    }
}

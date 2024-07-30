using Booking.DataAccess.Models;
using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class RoleProvider : BasicService
    {
        private BookingContext context;

        public RoleProvider(BookingContext booking)
        {
            this.context = booking;
        }

        public IndexRoleDTO AllRole(int page)
        {
            var dto = new IndexRoleDTO();
            using (var dbContext = new BookingContext())
            {
                var query = from role in dbContext.MstRoles
                            where !role.DeletedDate.HasValue
                            orderby role.Id
                            select new RowRoleDTO
                            {
                                Id = role.Id,
                                Name = role.Name,
                                CreatedBy = role.CreatedBy.ToString(),
                                CreatedDate = FormattingDate(role.CreatedDate),
                                UpdatedBy = role.UpadatedBy.ToString(),
                                UpdatedDate = FormattingDate(role.UpdatedDate)
                            };
                var totalData = GetTotalPage(query.Count());
                query = query.Skip(GetSkip(page)).Take(10);
                dto.Roles = query.ToList();
                dto.TotalPages = totalData;
            }
            return dto;
        }

        public void InsertRole(CreatedRoleDTO model)
        {
            var newData = new MstRole();
            newData.Name = model.Name;
            newData.CreatedDate = DateTime.UtcNow;
            newData.CreatedBy = 1;
            context.MstRoles.Add(newData);
            context.SaveChanges();
        }

        public MstRole GetRole(int id)
        {
            return context.MstRoles.SingleOrDefault(role => role.Id == id);
        }

        public void UpdateRole(CreatedRoleDTO model)
        {
            var getData = GetRole(model.Id);
            getData.Name = model.Name;
            getData.UpdatedDate = DateTime.UtcNow;
            getData.UpadatedBy = 1;
            context.SaveChanges();
        }

        public void DelteRole(int id)
        {
            var getData = GetRole(id);
            getData.DeletedDate = DateTime.UtcNow;
            getData.DeletedBy = 1;
            context.SaveChanges();
        }
    }
}

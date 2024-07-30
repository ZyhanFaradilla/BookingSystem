using Booking.DataAccess.Models;
using Booking.DataModel.Master.Resource;
using Booking.DataModel.Master.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class UserProvider : BasicService
    {
        private BookingContext context;

        public UserProvider(BookingContext booking)
        {
            this.context = booking;
        }

        public CreatedUserDTO GetBlankForm()
        {
            var dto = new CreatedUserDTO
            {
                RoleDropdown = GetRoleDropdown(),
            };
            return dto;
        }

        public IndexUserDTO AllUser(int page)
        {
            var dto = new IndexUserDTO();
            using (var dbContext = new BookingContext())
            {
                var query = from user in dbContext.MstUsers
                            where !user.DeletedDate.HasValue
                            orderby user.Id
                            select new RowUserDTO
                            {
                                Id = user.Id,
                                LoginName = user.LoginName,
                                RoleName = GetRole(user.RoleId),
                                CreatedBy = GetUserInsert(user.CreatedBy),
                                CreatedDate = FormattingDate(user.CreatedDate),
                                UpdatedBy = GetUserUpdate(user.UpdatedBy),
                                UpdatedDate = FormattingDate(user.UpdatedDate)
                            };
                var totalData = GetTotalPage(query.Count());
                query = query.Skip(GetSkip(page)).Take(10);
                dto.RowUsers = query.ToList();
                dto.TotalPages = totalData;
            }
            return dto;
        }

        public void InsertUser(CreatedUserDTO model)
        {
            var newData = new MstUser();
            newData.LoginName = model.LoginName;
            newData.Password = model.Password;
            newData.RoleId = model.RoleId;
            newData.Email = "contoh@email.com";
            newData.FirstName = "Contoh";
            newData.MiddleName = "User";
            newData.LastName = "Login";
            newData.CreatedDate = DateTime.UtcNow;
            newData.CreatedBy = 1;
            context.MstUsers.Add(newData);
            context.SaveChanges();
        }

        public MstUser GetUser(int id)
        {
            return context.MstUsers.SingleOrDefault(user => user.Id == id);
        }

        public void UpdateUser(CreatedUserDTO model)
        {
            var getData = GetUser(model.Id);
            getData.LoginName = model.LoginName;
            getData.Password = model.Password;
            getData.RoleId = model.RoleId;
            getData.Email = "contoh@email.com";
            getData.FirstName = "Contoh";
            getData.MiddleName = "User";
            getData.LastName = "Login";
            getData.UpdatedDate = DateTime.UtcNow;
            getData.UpdatedBy = 1;
            context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var getData = GetUser(id);
            getData.DeletedDate = DateTime.UtcNow;
            getData.DeletedBy = 1;
            context.SaveChanges();
        }
    }
}

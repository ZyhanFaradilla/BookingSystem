using Booking.DataAccess.Models;
using Booking.DataModel.Master.Resource;
using Booking.DataModel.Master.ResourceCode;
using Booking.DataModel.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public abstract class BasicService
    {
        protected const int _totalPage = 10;

        protected static int GetSkip(int page)
        {
            return (page - 1) * _totalPage;
        }
        protected static int GetTotalPage(int totalRows)
        {
            var decimalResult = (double)totalRows / (double)_totalPage;
            return (int)Math.Ceiling(decimalResult);
        }

        public static string FormattingDate(DateTime? date)
        {
            if (date == null)
            {
                return "";
            }
            else
            {
                var indoCulture = CultureInfo.CreateSpecificCulture("id-ID");
                return date.Value.ToString("dd MMMM yyyy", indoCulture);
            }
        }

        public IEnumerable<DropdownDTO> GetLocationDropdown()
        {
            IEnumerable<DropdownDTO> dto = new List<DropdownDTO>()
            {
                new DropdownDTO {Text = "No Location Selected", Value = "0"}
            };
            using (var dbContext = new BookingContext())
            {
                var query = from location in dbContext.MstLocations
                            orderby location.Name ascending
                            select new DropdownDTO
                            {
                                Text = location.Name,
                                Value = location.Id.ToString()
                            };
                dto = dto.Concat(query.ToList());
            }
            return dto;
        }

        public IEnumerable<DropdownDTO> GetRoleDropdown()
        {
            IEnumerable<DropdownDTO> dto = new List<DropdownDTO>()
            {
                new DropdownDTO {Text = "No Role Selected", Value = "0"}
            };
            using (var dbContext = new BookingContext())
            {
                var query = from role in dbContext.MstRoles
                            orderby role.Name ascending
                            select new DropdownDTO
                            {
                                Text = role.Name,
                                Value = role.Id.ToString()
                            };
                dto = dto.Concat(query.ToList());
            }
            return dto;
        }

        public static string GetLocation(int? id)
        {
            if (id == null || id == 0)
            {
                return " ";
            } else
            {
                using (var dbContext = new BookingContext())
                {
                    return dbContext.MstLocations.SingleOrDefault(location => location.Id == id).Name;
                }
            }
        }

        public static string GetRole(int id)
        {
            using (var dbContext = new BookingContext())
            {
                return dbContext.MstRoles.SingleOrDefault(role => role.Id == id).Name;
            }
        }

        public static string GetUserUpdate(int? id)
        {
            using (var dbContext = new BookingContext())
            {
                return dbContext.MstUsers.SingleOrDefault(user => user.Id == id).FirstName + " " + dbContext.MstUsers.SingleOrDefault(user => user.Id == id).MiddleName + " " + dbContext.MstUsers.SingleOrDefault(user => user.Id == id).LastName;
            }
        }

        public static string GetUserInsert(int id)
        {
            using (var dbContext = new BookingContext())
            {
                var firstName = dbContext.MstUsers.SingleOrDefault(user => user.Id == id).FirstName;
                var middleName = dbContext.MstUsers.SingleOrDefault(user => user.Id == id).MiddleName;
                var lastName = dbContext.MstUsers.SingleOrDefault(user => user.Id == id).LastName; ;
                return  firstName + " " + middleName + " " + lastName;
            }
        }

        public List<CheckboxDTO> GetResourceCodeCheckboxInsert()
        {
            List<CheckboxDTO> dto = new List<CheckboxDTO>();
            using (var dbContext = new BookingContext())
            {
                var query = from resource in dbContext.MstResources
                            where !resource.DeletedDate.HasValue && resource.Status == true
                            join resourceCode in dbContext.MstResourceCodes on resource.Id equals resourceCode.ResourceId
                            where resourceCode.IsActive == true
                            orderby resource.Name ascending
                            select new CheckboxDTO
                            {
                                Id = resourceCode.Id,
                                Name = resource.Name,
                                IsInsert = true
                            };
                dto = query.ToList();
            }
            return dto;
        }

        public List<CheckboxDTO> GetResourceCodeCheckboxUpdate(int id)
        {
            List<CheckboxDTO> dto = new List<CheckboxDTO>();
            using (var dbContext = new BookingContext())
            {
                // Filter out expired resources
                var transResRoom = dbContext.TransResourceRooms
                                           .Where(resRoom => resRoom.IsExpired == false || resRoom.IsExpired == null);

                var query = from resource in dbContext.MstResources
                            join resourceCode in dbContext.MstResourceCodes on resource.Id equals resourceCode.ResourceId
                            join transResourceRoom in transResRoom on resourceCode.Id equals transResourceRoom.ResourceCodeId into resourceRoomGroup
                            from transResourceRoom in resourceRoomGroup.DefaultIfEmpty()
                            where resource.DeletedDate == null
                                  && resource.Status == true
                                  && (transResourceRoom == null || transResourceRoom.RoomId == id || transResourceRoom.IsExpired == null)
                            orderby resource.Name ascending
                            select new CheckboxDTO
                            {
                                Id = resourceCode.Id,
                                Name = resource.Name,
                                IsInsert = true
                            };

                dto = query.ToList();
            }
            return dto;
        }

        public List<ResourceCodeDTO> GetResourceCodes(int id)
        {
            List<ResourceCodeDTO> dto = new List<ResourceCodeDTO>();
            using (var dbContext = new BookingContext())
            {
                var query = from resource in dbContext.MstResources
                            where !resource.DeletedDate.HasValue && resource.Id == id
                            join resourceCode in dbContext.MstResourceCodes on resource.Id equals resourceCode.ResourceId
                            orderby resourceCode.ResourceCode ascending
                            select new ResourceCodeDTO
                            {
                                Id = resourceCode.Id,
                                ResourceCode = resourceCode.ResourceCode,
                                Status = resourceCode.IsActive,
                                ResourceId = resource.Id
                            };
                dto = query.ToList();
            }
            return dto;
        }

        public static string GetRoomName(int id)
        {
            using (var dbContext = new BookingContext())
            {
                return dbContext.MstRooms.SingleOrDefault(room => room.Id == id).Name;
            }
        }
    }
}

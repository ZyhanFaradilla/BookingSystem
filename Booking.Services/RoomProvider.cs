using Booking.DataAccess.Models;
using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.Room;
using Booking.DataModel.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class RoomProvider : BasicService
    {
        private BookingContext context;

        public RoomProvider(BookingContext booking)
        {
            this.context = booking;
        }

        public IndexRoomDTO AllRoom(int page)
        {
            var dto = new IndexRoomDTO();
            using (var dbContext = new BookingContext())
            {
                var query = from room in dbContext.MstRooms
                            where !room.DeletedDate.HasValue
                            orderby room.Id
                            select new RowRoomDTO
                            {
                                Id = room.Id,
                                RoomName = room.Name,
                                Floor = room.Floor,
                                Description = room.Description,
                                Location = GetLocation(room.LocationId),
                                Capacity = room.Capacity,
                                RoomColor = room.Color
                            };
                var totalData = GetTotalPage(query.Count());
                query = query.Skip(GetSkip(page)).Take(10);
                dto.RowRooms = query.ToList();
                dto.TotalPages = totalData;
            }
            return dto;
        }

        public CreatedRoomDTO GetBlankFormInsertWithCode()
        {
            var dto = new CreatedRoomDTO
            {
                LocationDropdown = GetLocationDropdown(),
                ResourcesCheckbox = GetResourceCodeCheckboxInsert()
            };
            return dto;
        }

        public CreatedRoomDTO GetBlankFormUpdateWithCode(int id)
        {
            var dto = new CreatedRoomDTO
            {
                LocationDropdown = GetLocationDropdown(),
                ResourcesCheckbox = GetResourceCodeCheckboxUpdate(id)
            };
            return dto;
        }

        public List<int> GetInserResourceRoom(List<int> ids)
        {
            var resourceRoom = new List<int>();
            resourceRoom.AddRange(ids);
            return resourceRoom;
        }

        public void InsertRoomWithResourceCode(CreatedRoomDTO model)
        {
            var newData = new MstRoom();
            newData.Name = model.Name;
            newData.Floor = model.Floor;
            newData.Description = model.Description;
            newData.LocationId = model.LocationId;
            newData.Capacity = model.Capacity;
            newData.Color = model.ColorRoom;
            newData.CreatedDate = DateTime.UtcNow;
            newData.CreatedBy = 1;
            context.MstRooms.Add(newData);
            context.SaveChanges();

            foreach (var resource in model.ResourcesCheckbox)
            {
                if (resource.IsSelected)
                {
                    context.MstResourceCodes.SingleOrDefault(res => res.Id == resource.Id).IsActive = false;
                    model.Resources.Add(resource.Id);
                }
                else
                {
                    context.MstResourceCodes.SingleOrDefault(res => res.Id == resource.Id).IsActive = true;
                }
            }
            var resourceRooms = GetInserResourceRoom(model.Resources);
            foreach (var resourceRoomId in resourceRooms)
            {
                var roomResource = new TransResourceRoom
                {
                    RoomId = newData.Id,
                    ResourceCodeId = resourceRoomId,
                    IsExpired = false
                };
                context.TransResourceRooms.Add(roomResource);
            }
            context.SaveChanges();
        }

        public MstRoom GetRoom(int id)
        {
            return context.MstRooms.SingleOrDefault(room => room.Id == id);
        }

        public List<TransResourceRoom> GetResourceCodeRoom(int id)
        {
            return context.TransResourceRooms.Where(resource => resource.RoomId == id && resource.IsExpired == false).ToList();
        }

        public List<int> GetResourceCode(int id)
        {
            var roomResource = GetResourceCodeRoom(id);
            var resources = new List<int>();
            foreach (var resource in roomResource)
            {
                resources.Add(resource.ResourceCodeId.Value);
            }
            return resources;
        }

        public void UpdateRoomWithResourceCode(CreatedRoomDTO model)
        {
            var getData = GetRoom(model.Id);
            getData.Name = model.Name;
            getData.Floor = model.Floor;
            getData.Description = model.Description;
            getData.LocationId = model.LocationId;
            getData.Capacity = model.Capacity;
            getData.Color = model.ColorRoom;
            getData.UpdatedDate = DateTime.UtcNow;
            getData.UpdatedBy = 1;
            context.SaveChanges();
            foreach (var resource in model.ResourcesCheckbox)
            {
                var resRoomNull = context.TransResourceRooms.Where(resRoom => resRoom.IsExpired == null).SingleOrDefault(resRoom => resRoom.ResourceCodeId == resource.Id);
                if (resource.IsSelected)
                {
                    if (resRoomNull != null)
                    {
                        resRoomNull.IsExpired = false;
                        context.MstResourceCodes.SingleOrDefault(res => res.Id == resource.Id).IsActive = false;
                    } else
                    {
                        var resRoom = context.TransResourceRooms.Where(resRoom => resRoom.IsExpired == false).SingleOrDefault(resRoom => resRoom.ResourceCodeId == resource.Id);
                        if (resRoom == null)
                        {
                            model.Resources.Add(resource.Id);
                            var roomResource = new TransResourceRoom
                            {
                                RoomId = getData.Id,
                                ResourceCodeId = resource.Id,
                                IsExpired = false
                            };
                            context.TransResourceRooms.Add(roomResource);
                            context.MstResourceCodes.SingleOrDefault(res => res.Id == resource.Id).IsActive = false;
                        }
                        else
                        {
                            context.MstResourceCodes.SingleOrDefault(res => res.Id == resource.Id).IsActive = false;
                        }
                    }
                }
                else
                {
                    if (resRoomNull != null)
                    {
                        resRoomNull.IsExpired = true;
                    } else
                    {
                        var resRoom = context.TransResourceRooms.Where(resRoom => resRoom.IsExpired == false).SingleOrDefault(resRoom => resRoom.ResourceCodeId == resource.Id);
                        if (resRoom != null)
                        {
                            resRoom.IsExpired = null;
                        }
                    }
                    context.MstResourceCodes.SingleOrDefault(res => res.Id == resource.Id).IsActive = true;
                }
            }
            context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var getData = GetRoom(id);
            var getResource = context.TransResourceRooms.Where(resRoom => (resRoom.RoomId == id && resRoom.IsExpired == false) || (resRoom.RoomId == id && resRoom.IsExpired == null)).ToList();
            if (getResource != null)
            {
                foreach (var roomResource in getResource)
                {
                    var resourceCode = context.MstResourceCodes.SingleOrDefault(resCode => resCode.Id == roomResource.ResourceCodeId);
                    if (resourceCode != null)
                    {
                        resourceCode.IsActive = true;
                    }
                    roomResource.IsExpired = true;
                }
            }
            getData.DeletedDate = DateTime.UtcNow;
            getData.DeletedBy = 1;
            context.SaveChanges();
        }
    }
}

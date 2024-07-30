using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.Room;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Controllers
{
    public class RoomController : Controller
    {
        private RoomProvider service;

        public RoomController(RoomProvider service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var dto = service.AllRoom(page);
            ViewBag.Page = page;
            return View(dto);
        }

        [HttpGet]
        public IActionResult Created(int id)
        {
            var dto = new CreatedRoomDTO();
            var data = service.GetRoom(id);
            if (id != 0)
            {
                var resources = service.GetResourceCode(id);
                if (resources.Count() > 0)
                {
                    dto = service.GetBlankFormUpdateWithCode(id);
                }
                else
                {
                    dto = service.GetBlankFormInsertWithCode();
                }
                foreach (var resource in dto.ResourcesCheckbox)
                {
                    if (resources.Contains(resource.Id))
                    {
                        resource.IsInsert = false;
                        resource.IsSelected = true;
                    }
                    else
                    {
                        resource.IsSelected = false;
                    }
                }
                dto.Id = data.Id;
                dto.Name = data.Name;
                dto.Floor = data.Floor;
                dto.Capacity = data.Capacity;
                dto.Description = data.Description;
                dto.ColorRoom = data.Color;
                dto.LocationId = data.LocationId;
                return View(dto);
            }
            else
            {
                dto = service.GetBlankFormInsertWithCode();
                return View(dto);
            }
        }

        [HttpPost]
        public IActionResult Created(CreatedRoomDTO model)
        {
            try
            {
                if (model.Id != 0)
                {
                    service.UpdateRoomWithResourceCode(model);
                }
                else
                {
                    service.InsertRoomWithResourceCode(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteRoom(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.Role;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Controllers
{
    public class RoleController : Controller
    {
        private RoleProvider service;

        public RoleController(RoleProvider service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var dto = service.AllRole(page);
            ViewBag.Page = page;
            return View(dto);
        }

        [HttpGet]
        public IActionResult Created(int id)
        {
            var dto = new CreatedRoleDTO();
            var data = service.GetRole(id);
            if (id != 0)
            {
                dto.Id = data.Id;
                dto.Name = data.Name;
            }
            return View(dto);
        }

        [HttpPost]
        public IActionResult Created(CreatedRoleDTO model)
        {
            try
            {
                if (model.Id != 0)
                {
                    service.UpdateRole(model);
                }
                else
                {
                    service.InsertRole(model);
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
                service.DelteRole(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

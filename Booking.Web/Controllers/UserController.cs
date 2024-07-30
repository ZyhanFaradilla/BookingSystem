using Booking.DataModel.Master.Room;
using Booking.DataModel.Master.User;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Controllers
{
    public class UserController : Controller
    {
        private UserProvider service;

        public UserController(UserProvider service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var dto = service.AllUser(page);
            ViewBag.Page = page;
            return View(dto);
        }

        [HttpGet]
        public IActionResult Created(int id)
        {
            var dto = service.GetBlankForm();
            var data = service.GetUser(id);
            if (id != 0)
            {
                dto.Id = data.Id;
                dto.LoginName = data.LoginName;
                dto.Password = data.Password;
                dto.RoleId = data.RoleId;
            }
            return View(dto);
        }

        [HttpPost]
        public IActionResult Created(CreatedUserDTO model)
        {
            try
            {
                if (model.Id != 0)
                {
                    service.UpdateUser(model);
                }
                else
                {
                    service.InsertUser(model);
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
                service.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.Resource;
using Booking.DataModel.Master.ResourceCode;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Controllers
{
    public class ResourceCodeController : Controller
    {
        private ResourceCodeProvider service;

        public ResourceCodeController(ResourceCodeProvider service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Created(int id)
        {
            var dto = new ResourceCodeDTO();
            if (id > 0)
            {
                dto.ResourceId = id;
            }
            return View(dto);
        }

        [HttpPost]
        public IActionResult Created(ResourceCodeDTO model)
        {
            try
            {
                service.InserResourceCode(model);
                return RedirectToAction(controllerName: "Resource", actionName: "Created", routeValues: new { id = model.ResourceId });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.ResourceCode;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceCodeController : ControllerBase
    {
        private ResourceCodeProvider service;

        public ResourceCodeController(ResourceCodeProvider service)
        {
            this.service = service;
        }

        [HttpGet("index")]
        public ActionResult Get()
        {
            var dto = service.AllResourceCode();
            return Ok(dto);
        }

        [HttpPost("created")]
        public ActionResult Created(ResourceCodeDTO model)
        {
            try
            {
                if (model.Id != 0)
                {
                    service.UpdateResourceCode(model);
                }
                else
                {
                    service.InserResourceCode(model);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("/deleteResourceCode")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteResourceCode(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

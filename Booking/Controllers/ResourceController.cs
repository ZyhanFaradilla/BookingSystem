using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.Resource;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private ResourceProvider service;

        public ResourceController(ResourceProvider service)
        {
            this.service = service;
        }

        [HttpGet("page={page}")]
        public ActionResult Get(int page)
        {
            var dto = service.AllResource(page);
            return Ok(dto);
        }

        [HttpPost("created")]
        public ActionResult Created(CreatedResourceDTO model)
        {
            try
            {
                if (model.Id != 0)
                {
                    service.UpdateResource(model);
                }
                else
                {
                    service.InsertResource(model);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("/deleteResource")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteResource(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

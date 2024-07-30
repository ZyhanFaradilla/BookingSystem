using Booking.DataModel.Master;
using Booking.DataModel.Master.Resource;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private LocationProvider service;

        public LocationController(LocationProvider service)
        {
            this.service = service;
        }

        [HttpPost("created")]
        public ActionResult Created(CreatedLocation model)
        {
            try
            {
                if (model.Id != 0)
                {
                    service.UpdateLocation(model);
                }
                else
                {
                    service.InsertLoaction(model);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("/deleteLocation")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteLocation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

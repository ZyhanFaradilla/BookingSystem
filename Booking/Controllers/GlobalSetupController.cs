using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.GlobalSetup;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalSetupController : ControllerBase
    {
        private GlobalSetupProvider service;

        public GlobalSetupController(GlobalSetupProvider service)
        {
            this.service = service;
        }

        [HttpGet("page={page}")]
        public ActionResult Get(int page)
        {
            var dto = service.AllGlobalSetup(page);
            return Ok(dto);
        }

        [HttpPost("insert")]
        public ActionResult Inserted(CreatedGlobalSetupDTO model)
        {
            try
            {
                service.InsertGlobalSetup(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("update")]
        public ActionResult Updated(CreatedGlobalSetupDTO model)
        {
            try
            {
                service.UpdateGlobalSetup(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("/deleteGlobalSetup")]
        public IActionResult Delete(string parameterCode)
        {
            try
            {
                service.DeleteGlobalSetup(parameterCode);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

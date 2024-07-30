using Booking.DataModel.Master.BookingCode;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingCodeController : ControllerBase
    {
        private BookingCodeProvider service;

        public BookingCodeController(BookingCodeProvider service) { 
            this.service = service;
        }

        [HttpGet("page={page}")]
        public ActionResult Get(int page)
        {
            var dto = service.AllBookingCode(page);
            return Ok(dto);
        }

        [HttpPost("created")]
        public ActionResult Created(CreatedBookingCodeDTO model) {
            try
            {
                if (model.Id != 0)
                {
                    service.UpdateBookingCode(model);
                }
                else
                {
                    service.InsertBookingCode(model);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("/deleteBookingCode")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteBookingCode(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

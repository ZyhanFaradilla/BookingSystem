using Booking.DataModel.Master.Resource;
using Booking.DataModel.Master.Room;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private RoomProvider service;

        public RoomController(RoomProvider service)
        {
            this.service = service;
        }

        [HttpGet("page={page}")]
        public ActionResult Get(int page)
        {
            var dto = service.AllRoom(page);
            return Ok(dto);
        }

        [HttpPost("created")]
        public ActionResult Created(CreatedRoomDTO model)
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
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("/deleteRoom")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteRoom(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

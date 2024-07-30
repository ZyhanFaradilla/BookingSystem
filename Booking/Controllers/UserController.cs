using Booking.DataModel.Master.Room;
using Booking.DataModel.Master.User;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserProvider service;

        public UserController(UserProvider service)
        {
            this.service = service;
        }

        [HttpGet("page={page}")]
        public ActionResult Get(int page)
        {
            var dto = service.AllUser(page);
            return Ok(dto);
        }

        [HttpPost("created")]
        public ActionResult Created(CreatedUserDTO model)
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
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("/deleteUser")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

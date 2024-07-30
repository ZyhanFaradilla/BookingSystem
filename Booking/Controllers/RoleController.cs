using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.Role;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleProvider service;

        public RoleController(RoleProvider service)
        {
            this.service = service;
        }

        [HttpGet("page={page}")]
        public ActionResult Get(int page)
        {
            var dto = service.AllRole(page);
            return Ok(dto);
        }

        [HttpPost("created")]
        public ActionResult Created(CreatedRoleDTO model)
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
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("/deleteRole")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DelteRole(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

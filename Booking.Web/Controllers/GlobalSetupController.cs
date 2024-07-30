using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.GlobalSetup;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Controllers
{
    public class GlobalSetupController : Controller
    {
        private GlobalSetupProvider service;

        public GlobalSetupController(GlobalSetupProvider service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var dto = service.AllGlobalSetup(page);
            ViewBag.Page = page;
            return View(dto);
        }

        [HttpGet]
        public IActionResult Updated(string parameterCode)
        {
            var data = service.GetGlobalSetup(parameterCode);
            var dto = new CreatedGlobalSetupDTO();
            dto.ParamterCode = parameterCode;
            dto.ParamterName = data.ParameterName;
            dto.ParamterDesc = data.ParameterDescription;
            dto.ParamterValue = data.ParameterValue;
            return View(dto);
        }

        [HttpPost]
        public IActionResult Updated(CreatedGlobalSetupDTO model)
        {
            try
            {
                service.UpdateGlobalSetup(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Inserted() 
        { 
            var dto = new CreatedGlobalSetupDTO();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Inserted(CreatedGlobalSetupDTO model)
        {
            try
            {
                service.InsertGlobalSetup(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

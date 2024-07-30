using Booking.DataAccess.Models;
using Booking.DataModel.Master.BookingCode;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Controllers
{
    public class BookingCodeController : Controller
    {
        private BookingCodeProvider service;

        public BookingCodeController(BookingCodeProvider service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var dto = service.AllBookingCode(page);
            ViewBag.Page = page;
            return View(dto);
        }

        [HttpGet]
        public IActionResult Created(int id)
        {
            var dto = new CreatedBookingCodeDTO();
            var data = service.GetBookingCode(id);
            if (id != 0)
            {
                dto.Id = data.Id;
                dto.BookingCode = data.BookingCode;
                dto.Status = data.Status;
            }
            return View(dto);
        }

        [HttpPost]
        public IActionResult Created(CreatedBookingCodeDTO model)
        {
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
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteBookingCode(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

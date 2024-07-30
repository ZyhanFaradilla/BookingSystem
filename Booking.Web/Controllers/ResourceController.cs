using Booking.DataModel.Master.BookingCode;
using Booking.DataModel.Master.Resource;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace Booking.Web.Controllers
{
    public class ResourceController : Controller
    {
        //private readonly IHttpClientFactory _clientFactory;

        //public ResourceController(IHttpClientFactory clientFactory)
        //{
        //    _clientFactory = clientFactory;
        //}

        private ResourceProvider service;

        public ResourceController(ResourceProvider service)
        {
            this.service = service;
        }

        //[HttpGet]
        //public async Task<IActionResult> Index(int page)
        //{
        //    var model = new IndexResourceDTO();
        //    var client = _clientFactory.CreateClient();

        //    var response = await client.GetAsync("http://localhost:5262/api/Resource/page=1");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        var option = new JsonSerializerOptions
        //        {
        //            PropertyNameCaseInsensitive = true,
        //        };
        //        try
        //        {
        //            model = JsonSerializer.Deserialize<IndexResourceDTO>(responseString, option);
        //        }
        //        catch (Exception ex)
        //        {
        //            return View("Error", ex.Message);
        //        }
        //    }
        //    return View(model);
        //}

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var dto = service.AllResource(page);
            ViewBag.Page = page;
            return View(dto);
        }

        [HttpGet]
        public IActionResult Created(int id)
        {
            var dto = new CreatedResourceDTO();
            dto.Codes = service.GetResourceCodes(id);
            var data = service.GetResource(id);
            if (id != 0)
            {
                dto.Id = data.Id;
                dto.Name = data.Name;
                dto.Status = data.Status;
                dto.ResourceIcon = data.Icon;
            }
            return View(dto);
        }

        [HttpPost]
        public IActionResult Created(CreatedResourceDTO model, IFormFile imgIcon)
        {
            try
            {
                if (imgIcon != null && imgIcon.Length > 0)
                {
                    model.FileNameOnServer = "C:\\C#(.NET)\\Booking\\Booking.Web\\wwwroot\\images\\";
                    model.FileNameOnServer += imgIcon.FileName;
                    model.ResourceIcon = imgIcon.FileName;
                    using var stream = System.IO.File.Create(model.FileNameOnServer);
                    imgIcon.CopyTo(stream);
                    if (model.Id != 0)
                    {
                        service.UpdateResource(model);
                    }
                    else
                    {
                        service.InsertResource(model);
                    }
                    return RedirectToAction("Index");
                } else if (model.ResourceIcon != null)
                {
                    model.ResourceIcon = model.ResourceIcon;
                    if (model.Id != 0)
                    {
                        service.UpdateResource(model);
                    }
                    else
                    {
                        service.InsertResource(model);
                    }
                    return RedirectToAction("Index");
                } else
                {
                    model.ResourceIcon = "empty-folder.png";
                    if(model.Id != 0)
                    {
                        service.UpdateResource(model);
                    }
                    else
                    {
                        service.InsertResource(model);
                    }
                    return RedirectToAction("Index");
                }
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
                service.DeleteResource(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

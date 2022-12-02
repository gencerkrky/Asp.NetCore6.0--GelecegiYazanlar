using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _101_Controller.Controllers
{
    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrnekController : Controller
    {
        public IActionResult Index()
        {

           


            //view veri gönderme
            ViewBag.name = "Asp.Net Core";

            ViewData["age"] = 30;

            ViewData["names"] = new List<string>() { "ahmet", "mehmet", "hasan" };

            // index2 ye veri taşıma (sayfalar arası)
            TempData["surname"] = "karakaya";

            return View();
        }

        public IActionResult Index2()
        {

            var surName = TempData["surname"];

            return View();
        }

        public IActionResult Index3()
        { //sayfa Yönlendirme (sayfa,sayfanın bulundugu controller)
            return RedirectToAction("Index", "Ornek");
        }
        public IActionResult Index4()
        {
            var productList = new List<Product2>()
            {
                new(){Id= 1, Name="Kalem"},
                new(){Id= 2, Name="Defter"},
                new(){Id= 3, Name="Silgi"},
            };

            return View(productList);
        }

        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }

        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, Name = "Kalem", price = 100 });
        }
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }


    }
}

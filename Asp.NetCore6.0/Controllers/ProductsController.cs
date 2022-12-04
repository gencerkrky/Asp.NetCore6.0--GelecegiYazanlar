using _101_Controller.Models;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using System.Linq;
using System.Security.AccessControl;
using Turkcell.Models;

namespace _101_Controller.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;


        private readonly ProductRepository _productRepository;

        public ProductsController(AppDbContext context)
        {
            //DI Container hazır frameworkte gömülü oldugu için herhangibi bir class constructor gectigimiz anda diger container bir nesne örgenigi contexte üretiyor
            //Dependency Injection Pattern
            _productRepository = new ProductRepository();


            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            _productRepository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            //1.Yöntem

            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            //2. yöntem
            //Product newProduct = new Product() { Name = Name, Price = Price, Stock = Stock, Color = Color };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla eklendi";

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product updateProduct)
        {

            _context.Products.Update(updateProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi";


            return RedirectToAction("Index");
        }
    }
}

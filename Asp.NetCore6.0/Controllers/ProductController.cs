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

            
            _context=context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList() ;

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
        public IActionResult SaveProduct()
        {
            return View();
        }
        public IActionResult Update(int id) 
        {
            return View();
        }
    }
}

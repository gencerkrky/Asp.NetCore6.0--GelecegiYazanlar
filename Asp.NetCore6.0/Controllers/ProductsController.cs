using _101_Controller.Models;
using Asp.NetCore6._0.Models;
using Asp.NetCore6._0.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Models;
using System.Linq;
using System.Security.AccessControl;
using Turkcell.Models;

namespace _101_Controller.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;

        private readonly IMapper _mapper;


        private readonly ProductRepository _productRepository;

        public ProductsController(AppDbContext context, IMapper mapper)
        {
            //DI Container hazır frameworkte gömülü oldugu için herhangibi bir class constructor gectigimiz anda diger container bir nesne örgenigi contexte üretiyor
            //Dependency Injection Pattern
            _productRepository = new ProductRepository();


            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult Remove(int id)
        {
            _productRepository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 },
            };


            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>
            {
                new(){Data="Mavi",Value="Mavi"},
                new(){Data="Kırmızı",Value="Kırmızı"},
                new(){Data="Sarı",Value="Sarı"},
                new(){Data="Yeşil",Value="Yesil"},

            }, "Value", "Data");


            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            //1.Yöntem

            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            //2. yöntem
            //Product newProduct = new Product() { Name = Name, Price = Price, Stock = Stock, Color = Color };


            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 },
            };


            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>
            {
                new(){Data="Mavi",Value="Mavi"},
                new(){Data="Kırmızı",Value="Kırmızı"},
                new(){Data="Sarı",Value="Sarı"},
                new(){Data="Yeşil",Value="Yesil"},

            }, "Value", "Data");


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(_mapper.Map<Product>(newProduct));
                    _context.SaveChanges();
                    TempData["status"] = "Ürün başarıyla eklendi";

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError(String.Empty, "Ürün Kaydedilirken hata meydana geldi. Lütfen daha sonra deneyiniz");
                    return View();

                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.ExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 },
            };


            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>
            {
                new(){Data="Mavi",Value="Mavi"},
                new(){Data="Kırmızı",Value="Kırmızı"},
                new(){Data="Sarı",Value="Sarı"},
                new(){Data="Yeşil",Value="Yesil"},

            }, "Value", "Data", product.Color);


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


        [Route("[controller]/[action]/page/{page}/pagesize/{pagesize}")]
        [HttpGet]
        public IActionResult GetData(int page, int pageSize)
        {


            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult HasProductName(string Name)
        {

            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());

            if (anyProduct)
            {
                return Json("Kaydetmeye çalıştığınız ürün ismi veritabanında bulunmaktadır.");
            }
            else
            {
                return Json(true);
            }




        }




    }
}

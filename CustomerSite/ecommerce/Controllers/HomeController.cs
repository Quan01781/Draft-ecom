using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ecommerce.Models;
using CustomerSite.Clients;

namespace ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductClient productClient;

        public HomeController(ILogger<HomeController> logger, IProductClient productClient)
        {
            _logger = logger;
            this.productClient = productClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> Product()
        {
            var products = await productClient.GetAllProduct();

            return View(products);
        }


        public async Task<IActionResult> ProductByFilter()
        {
            var products = await productClient.GetProductByFilter();

            return View(products);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
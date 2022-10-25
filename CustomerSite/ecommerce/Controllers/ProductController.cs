using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CustomerSite.Clients;
using ecommerce.Controllers;

namespace ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductClient productClient;

        public ProductController(IProductClient productClient)
        {
            this.productClient = productClient;
        }
        public async Task<IActionResult> ProductByID(int ID)
        {
            var products = await productClient.GetProductByID(ID);

            return View(products);
        }
    }
}

using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CustomerSite.Clients;
using ecommerce.Controllers;
using CustomerSite;
using ShareViewModel.DTO;
using System.Collections.Generic;
using ShareViewModel;

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

        public async Task<IActionResult> ProductByCategory(int ID, int pageNumber=1)
        {
            var products = await productClient.GetProductByCategory(ID);
            return View (products);
            //return View(await PaginatedList<ProductsDTO>.CreateAsync(products,pageNumber,5));
        }

        public async Task<IActionResult> RatingProduct(IFormCollection form) {
            string Comment = form["comment"];
            int Star = int.Parse(form["star"]);
            int ProductID = int.Parse(form["ID"]);

            var rating = await productClient.AddRating(Star,Comment, ProductID);
            return RedirectToAction("ProductByID", "Product", new { ID = ProductID });
        }
    }
}


using CustomerSite.Clients;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Controllers
{
   
    public class ProductsController : Controller
    {

        private readonly IProductClient _productClient;
        //public ProjectServices _projectServices;
        //private ShopDbContext _context;

        public ProductsController(IProductClient productClient)
        {
            _productClient = productClient;
        }

        public IActionResult GetAllProducts()
        {
            var allProducts = _productClient.GetAllProduct();

            return Json(allProducts);
        }

        //[Route("{id}")]
        //public IActionResult GetProductById(int id)
        //{
        //    var Product = _productClient.GetProductById(id);

        //    return Json(Product);
        //}

        //[HttpPost("add-product")]
        //public IActionResult AddProduct(Products product)
        //{
        //    _projectServices.AddProduct(product);
        //    return Ok();
        //}



    }

}

using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class APIproductsController : ControllerBase
    {
        public ProjectServices _projectServices;
        //private ShopDbContext _context;

        public APIproductsController(ProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            var allProducts = _projectServices.GetAllProducts();

            return Ok(allProducts);
        }

        [HttpGet("{ID}")]
        public IActionResult GetProductByID(int ID)
        {
            var Product = _projectServices.GetProductByID(ID);

            return Ok(Product);
        }

        //[HttpPost("add-product")]
        //public IActionResult AddProduct(Products product) {
        //    _projectServices.AddProduct(product);
        //    return Ok();
        //}

        [HttpGet("search/{searchstring}")]
        public IActionResult GetProductByFilter(string searchstring) 
        {
            var ProductFilter = _projectServices.GetProductByCharacter(searchstring);

            return Ok(ProductFilter);
        }

        //[HttpPost]
        //public async Task<ActionResult<Products>> PostProducts(Products productitem)
        //{
        //    _context.Products.Add(productitem);
        //    await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        //    return CreatedAtAction(nameof(GetTodoItem), new { id = productitem.ID }, productitem);
        //}
    }
}

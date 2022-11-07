using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProjectServices _projectServices;
        //private ShopDbContext _context;

        public ProductsController(ProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            var allProducts = _projectServices.GetAllProducts();

            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var Product = _projectServices.GetProductById(id);

            return Ok(Product);
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct(Products product) {
            _projectServices.AddProduct(product);
            return Ok();
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

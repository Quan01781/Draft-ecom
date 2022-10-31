using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareViewModel.DTO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using ShareViewModel.DTO;

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


        [HttpGet("get-all-categories")]
        public IActionResult GetAllCategories()
        {
            var allCategories = _projectServices.GetAllCategories();

            return Ok(allCategories);
        }


        [HttpGet("category")]
        public IActionResult GetProductByCategory([FromQuery]int ID)
        {
            var Product = _projectServices.GetProductByCategory(ID);

            return Ok(Product);
        }

        //rating
        [HttpPost("ratings")]
        public Task<RatingDTO> AddRating([FromBody]AddRatingDto addrating)
        {
            var results = _projectServices.AddRating(addrating);
            return results;
        }


        [HttpGet("product/{productId}")]
        public IActionResult getProductRating(int ProductID)
        {
            var result =  _projectServices.GetRatingByProductID(ProductID);
            return Ok(result);
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

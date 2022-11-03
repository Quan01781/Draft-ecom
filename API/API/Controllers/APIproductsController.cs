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

        [HttpPost("add-product")]
        public ActionResult<Products> AddProduct([FromBody] AdminProductDTO addproduct)
        {
            var result = _projectServices.AddProduct(addproduct);
            return Ok(result);
        }

        [HttpPost("update-product/{ID}")]
        public ActionResult<Products> UpdateProduct([FromBody] AdminProductDTO product, int ID)
        {
            var results = _projectServices.UpdateProduct(product, ID);
            return Ok(results);
        }

        [HttpPost("delete-product/{ID}")]
        public IActionResult DeleteProduct(int ID)
        {
            _projectServices.DeleteProduct(ID);
            return Ok();
        }

        [HttpGet("{ID}")]
        public IActionResult GetProductByID(int ID)
        {
            var Product = _projectServices.GetProductByID(ID);

            return Ok(Product);
        }

        //search
        [HttpGet("addmin-search/{searchstring}")]
        public IActionResult GetProductByFilter(string searchstring)
        {
            var Product = _projectServices.GetProductByCharacter(searchstring);

            return Ok(Product);
        }

        [HttpGet("search/{searching}")]
        public ActionResult<ProductsDTO> GetProductBySearch(string searching)
        {
            var Product = _projectServices.GetProductBySearch(searching);
            return Ok(Product);
        }

        //category
        [HttpGet("get-all-categories")]
        public IActionResult GetAllCategories()
        {
            var allCategories = _projectServices.GetAllCategories();

            return Ok(allCategories);
        }


        [HttpPost("add-category")]
        public ActionResult<AdminCategoryDTO> AddCategory([FromBody] AdminCategoryDTO addcategory)
        {
            var results = _projectServices.AddCategory(addcategory);
            return results;
        }

        [HttpPost("update-category/{ID}")]
        public ActionResult<AdminCategoryDTO> UpdateCategory([FromBody] AdminCategoryDTO category, int ID)
        {
            var results = _projectServices.UpdateCategory(category,ID);
            return Ok(results);
        }

        [HttpPost("delete-category/{ID}")]
        public IActionResult DeleteCategory(int ID) 
        {
            _projectServices.DeleteCategory(ID);
            return Ok();
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
        
    }
}

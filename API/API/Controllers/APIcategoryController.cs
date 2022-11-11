using API.Services;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel.DTO;
using API.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class APIcategoryController : ControllerBase
    {
    
        private readonly ICategoryService _categoryServices;

        public APIcategoryController(ICategoryService categoryService) 
        {
            _categoryServices = categoryService;
        }

        //category
        [HttpGet("get-all-categories")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var allCategories = await _categoryServices.GetAllCategories();

            return allCategories;
        }


        [HttpPost("add-category")]
        public async Task<ActionResult<AdminCategoryDTO>> AddCategory([FromBody] AdminCategoryDTO addcategory)
        {
            var results = await _categoryServices.AddCategory(addcategory);
            return results;
        }

        [HttpPut("update-category/{ID}")]
        public async Task<ActionResult<AdminCategoryDTO>> UpdateCategory([FromBody] AdminCategoryDTO category, int ID)
        {
            var results = await _categoryServices.UpdateCategory(category, ID);
            return results;
        }

        [HttpDelete("delete-category/{ID}")]
        public IActionResult DeleteCategory(int ID)
        {
            _categoryServices.DeleteCategory(ID);
            return Ok();
        }

        [HttpGet("category/{ID}")]
        public IActionResult GetCategoryByID(int ID) 
        {
            var result = _categoryServices.GetCategoryByID(ID);
            return Ok(result);
        }


        [HttpGet("products")]
        public IActionResult GetProductByCategory([FromQuery] int ID)
        {
            var Product = _categoryServices.GetProductByCategory(ID);

            return Ok(Product);
        }
    }
}

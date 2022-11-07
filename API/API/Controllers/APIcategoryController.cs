using API.Services;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class APIcategoryController : ControllerBase
    {
        public CategoryServices _categoryServices;

        public APIcategoryController(CategoryServices categoryServices) 
        {
            _categoryServices = categoryServices;
        }

        //category
        [HttpGet("get-all-categories")]
        public IActionResult GetAllCategories()
        {
            var allCategories = _categoryServices.GetAllCategories();

            return Ok(allCategories);
        }


        [HttpPost("add-category")]
        public ActionResult<AdminCategoryDTO> AddCategory([FromBody] AdminCategoryDTO addcategory)
        {
            var results = _categoryServices.AddCategory(addcategory);
            return results;
        }

        [HttpPut("update-category/{ID}")]
        public ActionResult<AdminCategoryDTO> UpdateCategory([FromBody] AdminCategoryDTO category, int ID)
        {
            var results = _categoryServices.UpdateCategory(category, ID);
            return Ok(results);
        }

        [HttpDelete("delete-category/{ID}")]
        public IActionResult DeleteCategory(int ID)
        {
            _categoryServices.DeleteCategory(ID);
            return Ok();
        }

        [HttpGet("category")]
        public IActionResult GetProductByCategory([FromQuery] int ID)
        {
            var Product = _categoryServices.GetProductByCategory(ID);

            return Ok(Product);
        }
    }
}

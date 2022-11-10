using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareViewModel.DTO;
using System.Runtime.InteropServices;
using System.Xml.Linq;


namespace API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class APIproductsController : ControllerBase
    {
        public ProductServices _projectServices;


        public APIproductsController(ProductServices projectServices)
        {
            _projectServices = projectServices;
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            var allProducts = _projectServices.GetAllProducts();

            return Ok(allProducts);
        }


        [HttpGet("admin/get-all-products")]
        public IActionResult GetAllProductsByAdmin()
        {
            var allProducts = _projectServices.GetAllProductsByAdmin();

            return Ok(allProducts);
        }


        [HttpGet("admin/product/{ID}")]
        public IActionResult GetProductByIDAdmin(int ID)
        {
            var result = _projectServices.GetProductByIDAdmin(ID);
            return Ok(result);
        }

        [HttpPost("add-product")]
        public ActionResult<Products> AddProduct([FromBody] AdminProductDTO addproduct)
        {
            var result = _projectServices.AddProduct(addproduct);
            return Ok(result);
        }

        [HttpPost("add-image")]
        public ActionResult UploadFile([FromForm] ImageDTO file) 
        {
            var result = _projectServices.UploadFile(file);
            return Ok(result);
        }

        [HttpPut("update-product/{ID}")]
        public ActionResult<Products> UpdateProduct([FromBody] AdminProductDTO product, int ID)
        {
            var results = _projectServices.UpdateProduct(product, ID);
            return Ok(results);
        }

        [HttpDelete("delete-product/{ID}")]
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
        [HttpGet("admin-search/{searchstring}")]
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
        
    }
}

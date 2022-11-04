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
        
    }
}

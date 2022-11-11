using API.Interfaces;
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
        private readonly IProductService _productServices;

        public APIproductsController(IProductService productService)
        {
            _productServices = productService;
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            var allProducts = _productServices.GetAllProducts();

            return Ok(allProducts);
        }


        [HttpGet("admin/get-all-products")]
        public IActionResult GetAllProductsByAdmin()
        {
            var allProducts = _productServices.GetAllProductsByAdmin();

            return Ok(allProducts);
        }


        [HttpGet("admin/product/{ID}")]
        public IActionResult GetProductByIDAdmin(int ID)
        {
            var result = _productServices.GetProductByIDAdmin(ID);
            return Ok(result);
        }

        [HttpPost("add-product")]
        public ActionResult<Products> AddProduct([FromBody] AdminProductDTO addproduct)
        {
            var result = _productServices.AddProduct(addproduct);
            return Ok(result);
        }

        [HttpPost("add-image")]
        public ActionResult UploadFile([FromForm] ImageDTO file) 
        {
            var result = _productServices.UploadFile(file);
            return Ok(result);
        }

        [HttpPut("update-product/{ID}")]
        public ActionResult<Products> UpdateProduct([FromBody] AdminProductDTO product, int ID)
        {
            var results = _productServices.UpdateProduct(product, ID);
            return Ok(results);
        }

        [HttpDelete("delete-product/{ID}")]
        public IActionResult DeleteProduct(int ID)
        {
            _productServices.DeleteProduct(ID);
            return Ok();
        }

        [HttpGet("{ID}")]
        public IActionResult GetProductByID(int ID)
        {
            var Product = _productServices.GetProductByID(ID);

            return Ok(Product);
        }

        //search
        [HttpGet("admin-search/{searchstring}")]
        public IActionResult GetProductByFilter(string searchstring)
        {
            var Product = _productServices.GetProductBySearchAdmin(searchstring);

            return Ok(Product);
        }

        [HttpGet("search/{searching}")]
        public ActionResult<ProductsDTO> GetProductBySearch(string searching)
        {
            var Product = _productServices.GetProductBySearch(searching);
            return Ok(Product);
        }
        
    }
}

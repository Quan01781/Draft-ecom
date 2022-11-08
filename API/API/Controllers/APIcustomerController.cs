using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class APIcustomerController : ControllerBase
    {
        public CustomerServices _customerServices;

        public APIcustomerController(CustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("get-all-customers")]
        public IActionResult GetAllCustomers()
        {
            var allCustomers = _customerServices.GetAllCustomers();

            return Ok(allCustomers);
        }

        [HttpGet("customer/{ID}")]
        public IActionResult GetCustomerByID(int ID) 
        {
            var result = _customerServices.GetCustomerByID(ID);
            return Ok(result);
        }
    }
}

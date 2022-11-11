using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class APIcustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public APIcustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get-all-customers")]
        public IActionResult GetAllCustomers()
        {
            var allCustomers = _customerService.GetAllCustomers();

            return Ok(allCustomers);
        }

        [HttpGet("customer/{ID}")]
        public IActionResult GetCustomerByID(int ID) 
        {
            var result = _customerService.GetCustomerByID(ID);
            return Ok(result);
        }
    }
}

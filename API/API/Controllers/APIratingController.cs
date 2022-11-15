using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Models;
using ShareViewModel.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/rating")]
    public class APIratingController : ControllerBase
    {
        private readonly IRatingService _ratingServices;
        public APIratingController(IRatingService ratingServices)
        {
            _ratingServices = ratingServices;
        }

        //rating
        [HttpPost("ratings")]
        public Task<RatingDTO> AddRating([FromBody] AddRatingDto addrating)
        {
            var results = _ratingServices.AddRating(addrating);
            return results;
        }


        [HttpGet("product/{ProductID}")]
        public ActionResult<RatingDTO> getProductRating(int ProductID)
        {
            var result = _ratingServices.GetRatingByProductID(ProductID);
            return Ok(result);
        }
    }
}

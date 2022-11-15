using API.Models;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel.DTO;


namespace API.Interfaces
{
    public interface IRatingService
    {
        List<RatingDTO> GetRatingByProductID(int ProductID);
        Task<RatingDTO> AddRating(AddRatingDto ratingDto);
    }
}

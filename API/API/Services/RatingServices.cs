using API.Models;
using Microsoft.EntityFrameworkCore;
using ShareViewModel.DTO;
using System.Collections.Immutable;
using X.PagedList;

namespace API.Services
{
    public class RatingServices
    {
        private ShopDbContext _context;
        public RatingServices(ShopDbContext context)
        {
            _context = context;
        }

        
        public List<RatingDTO> GetRatingByProductID(int ProductID)
        {
            var result = _context.Ratings.Where(r => r.ProductID == ProductID).ToList();
            var ratingList = new List<RatingDTO>();
            foreach (var rating in result)
            {
                var ratingDTO = new RatingDTO();
                ratingDTO.ID = rating.ID;
                ratingDTO.Star = rating.Star;
                ratingDTO.Content = rating.Content;
                ratingDTO.ProductID = rating.ProductID;
                ratingDTO.CreateDate = rating.CreateDate;
   
                ratingList.Add(ratingDTO);

            }
            return ratingList;
        }

        //add rating
        public async Task<RatingDTO> AddRating(AddRatingDto ratingDto)
        {
            var rating = new Rating();
            rating.ProductID = ratingDto.ProductID;
            //rating.Product = await _context.Products.FirstOrDefaultAsync(p => p.ID == ratingDto.ProductID);
            rating.CreateDate = DateTime.Now;
            rating.Star = ratingDto.Star;
            rating.Content = ratingDto.Content;

            var product = await _context.Products.FirstOrDefaultAsync(p => p.ID == ratingDto.ProductID);

            if (product == null)
            {
                throw new Exception("Can not find Product");
            }

            _context.Ratings.Add(rating);
            _context.SaveChanges();

            return new RatingDTO()
            {
                ID = rating.ID,
                Content = rating.Content,
                Star = rating.Star
            };

        }
    }
}

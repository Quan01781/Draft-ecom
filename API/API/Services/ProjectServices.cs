using API.Models;
using Microsoft.EntityFrameworkCore;
using ShareViewModel.DTO;
using X.PagedList;

namespace API.Services
{
    public class ProjectServices
    {
        private ShopDbContext _context;
        public ProjectServices(ShopDbContext context)
        {
            _context = context;
        }

        public List<Products> GetAllProducts() => _context.Products.ToList();
        public ProductsDTO GetProductByID(int ID)
        {
            var x = _context.Products.Where(x => x.ID == ID).Include(x => x.Ratings).FirstOrDefault();
            ProductsDTO products = new ProductsDTO()
            {
                ID = x.ID,
                Name = x.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                CategoryID = (int)x.CategoryID!,
                Image = x.Image,
                Description = x.Description,
                Ratings = new List<RatingDTO>(),
            };
            foreach (var rating in x.Ratings)
            {
                var ratingDto = new RatingDTO()
                {
                    ID = rating.ID,
                    ProductID = rating.ProductID,
                    Content = rating.Content,
                    CreateDate = rating.CreateDate,
                    Star = rating.Star,
                };
                products.Ratings.Add(ratingDto);
            }
            return products;


        }

        public async Task<double> AverageStar(int ID)
        {
            double result = 0;

            try
            {
                result = await _context.Products.Where(p => p.ID == ID).Select(p => p.Ratings.Average(r => r.Star)).FirstOrDefaultAsync();
            }
            catch (System.Exception)
            {
                result = 0;
            }
            return result;
        }

        public List<Products> GetProductByCharacter(string searchstring) => _context.Products.Where(x => x.Name.Contains(searchstring)).ToList();


        public List<Category> GetAllCategories() => _context.Category.ToList();
        public List<Products> GetProductByCategory(int ID) 
        {
            //var pageNumber = page ?? 1;
            //var pageSize = 10;
            //var productList= _context.Products.OrderByDescending(x => x.ID).Where(x => x.CategoryID == ID).ToPagedList(pageNumber, pageSize).ToList();
            var productList = _context.Products.OrderByDescending(x => x.ID).Where(x => x.CategoryID == ID).ToList();
            return productList;
        }

        //rating
        public List<Rating> GetRatingByProductID(int ProductID) {
            return _context.Ratings.OrderByDescending(r=>r.CreateDate).Where(r => r.ProductID == ProductID).ToList();
        }

        public async Task<RatingDTO> AddRating(AddRatingDto ratingDto) 
        {
            var rating = new Rating();
            rating.ProductID = ratingDto.ProductID;
            //rating.Product = await _context.Products.FirstOrDefaultAsync(p => p.ID == ratingDto.ProductID);
            rating.CreateDate = DateTime.Now;
            rating.Star = ratingDto.Star;
            rating.Content = ratingDto.Content;

            var product = await _context.Products.FirstOrDefaultAsync(p => p.ID == ratingDto.ProductID);

            if(product == null)
            {
                throw new Exception("Can not find Product");
            }

            _context.Ratings.Add(rating);
            
            _context.SaveChanges();
       
            return new RatingDTO() { 
                ID = rating.ID,
                Content = rating.Content,
                Star = rating.Star
            };

        }

        //public void AddProduct(Products products) {
        //    var _product = new Products();

        //    _product.ID = products.ID;
        //    _product.Name = products.Name;
        //    _product.Quantity = products.Quantity;
        //    _product.Price = products.Price;


        //    _context.Products.Add(_product);
        //    _context.SaveChanges();
        //}

    }
}

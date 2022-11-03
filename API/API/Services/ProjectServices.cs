using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ShareViewModel.DTO;
using System.Collections.Immutable;
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
            var x = _context.Products.Where(x => x.ID == ID).Include(x => x.Ratings.OrderByDescending(i=>i.ID)).FirstOrDefault();
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

        public Products AddProduct(AdminProductDTO addproduct) 
        {
            var product = new Products();
            product.ID = addproduct.ID;
            product.Name = addproduct.Name;
            product.Quantity = addproduct.Quantity;
            product.Price = addproduct.Price;
            product.CategoryID = addproduct.CategoryID;
            product.Image = addproduct.Image;
            product.Description = addproduct.Description;
            product.Created_by = addproduct.Created_by;
            product.Created_at = DateTime.Now;
            product.Updated_at = DateTime.Now;
         
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public Products UpdateProduct(AdminProductDTO updateproduct, int ID)
        {
            var product = _context.Products.Where(c => c.ID == ID).FirstOrDefault();
            if (product != null)
            {
                product.Name = updateproduct.Name;
                product.Quantity = updateproduct.Quantity;
                product.Price = updateproduct.Price;
                product.CategoryID=updateproduct.CategoryID;
                product.Image = updateproduct.Image;
                product.Description = updateproduct.Description;
                product.Updated_at = DateTime.Now;
                _context.SaveChanges();
            }

            return product;
        }
        public int DeleteProduct(int ID) 
        {
            var product = _context.Products.Where(c => c.ID == ID).FirstOrDefault();
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return 0;
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

        //search
        public List<Products> GetProductByCharacter(string searchstring) => _context.Products.Where(x => x.Name.Contains(searchstring)).ToList();

        public List<ProductsDTO> GetProductBySearch(string searchstring)
        {
            var result = _context.Products.Where(x => x.Name.Contains(searchstring)).ToList();
            var products = new List<ProductsDTO>();
            foreach (var product in result)
            {
                var productDTO = new ProductsDTO();
                productDTO.ID = product.ID;
                productDTO.Name = product.Name;
                productDTO.Price = product.Price;
                productDTO.Quantity = product.Quantity;
                productDTO.Image = product.Image;
                productDTO.Description = product.Description;
                products.Add(productDTO);

            }
            return products;
        }

        //category
        public List<Category> GetAllCategories() => _context.Category.ToList();
        public AdminCategoryDTO AddCategory(AdminCategoryDTO addcategory) 
        {
            var category = new Category();
            category.ID = addcategory.ID;   
            category.Name = addcategory.Name;
            category.Created_by = addcategory.Created_by;
            category.Created_at = DateTime.Now;
            category.Updated_at = DateTime.Now;

            _context.Category.Add(category);
            _context.SaveChanges();

            return new AdminCategoryDTO()
            {
                ID = category.ID,
                Name = category.Name,
                Created_by=category.Created_by,
                Created_at = category.Created_at,
                Updated_at = category.Updated_at,
            };
        }

        public AdminCategoryDTO UpdateCategory(AdminCategoryDTO updatecategory, int ID) 
        {
            var category =  _context.Category.Where(c => c.ID == ID).FirstOrDefault();
            if (category != null) 
            {
                category.Name = updatecategory.Name;
                category.Updated_at = DateTime.Now;
                _context.SaveChanges();
            }

            return new AdminCategoryDTO() 
            {
                ID=category.ID,
                Name=category.Name,
                Created_by=category.Created_by,
                Created_at=category.Created_at,
                Updated_at=category.Updated_at,
            };
        }

        public int DeleteCategory(int ID)
        {

            var category =  _context.Category.Where(c => c.ID == ID).FirstOrDefault();
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
            }
            return 0;
        }
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

    }
}

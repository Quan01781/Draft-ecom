using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ShareViewModel.DTO;
using System.Collections.Immutable;
using X.PagedList;

namespace API.Services
{
    public class ProductServices : IProductService
    {
        private ShopDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductServices(ShopDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Products> GetAllProductsByAdmin() => _context.Products.ToList();

        public List<ProductsDTO> GetAllProducts() {
            var result = _context.Products.ToList();
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

        public ProductsDTO GetProductByID(int ID)
        {
            var x = _context.Products.Where(x => x.ID == ID).Include(x => x.Ratings.OrderByDescending(i=>i.ID)).FirstOrDefault();
            
            ProductsDTO products = new ProductsDTO()
            {
                ID = x.ID,
                Name = x.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                Image = x.Image,
                Description = x.Description,
                Color = x.Color,
                Size = x.Size,
                Ratings = new List<RatingDTO>(),
            };
            
            foreach (var rating in x.Ratings)
            {
                var ratingDto = new RatingDTO()
                {
                    ID = rating.ID,
                    ProductID = rating.ProductID,
                    Content = rating.Content,
                    Created_at = rating.Created_at,
                    Star = rating.Star,
                };
                products.Ratings.Add(ratingDto);
                
            }
            return products;


        }

        public Products GetProductByIDAdmin(int ID) => _context.Products.Where(p => p.ID == ID).FirstOrDefault();

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

        public string UploadFile(ImageDTO file) 
        {
            string fileName = file.FileName;
            if (file.FormFile != null) {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/Image/product", file.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                } }
            return fileName;
           
        }

        public Products UpdateProduct(AdminProductDTO updateproduct, int ID)
        {
            var product = _context.Products.Where(c => c.ID == ID).FirstOrDefault();

            if (updateproduct.Name!="") { product.Name = updateproduct.Name; }
            if (updateproduct.Quantity != null) { product.Quantity = updateproduct.Quantity; }
            if (updateproduct.Price != null) { product.Price = updateproduct.Price; }
            if (updateproduct.CategoryID != null) { product.CategoryID = updateproduct.CategoryID; }
            if (updateproduct.Image != "") { product.Image = updateproduct.Image; }
            if (updateproduct.Description != "") { product.Description = updateproduct.Description; }
                product.Updated_at = DateTime.Now;
                _context.SaveChanges();
            

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
        //public async Task<double> AverageStar(int ID)
        //{
        //    double result = 0;

        //    try
        //    {
        //        result = await _context.Products.Where(p => p.ID == ID).Select(p => p.Ratings.Average(r => r.Star)).FirstOrDefaultAsync();
        //    }
        //    catch (System.Exception)
        //    {
        //        result = 0;
        //    }
        //    return result;
        //}

        //search
        public List<Products> GetProductBySearchAdmin(string searchstring) => _context.Products.Where(x => x.Name.Contains(searchstring)).ToList();

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

    }
}

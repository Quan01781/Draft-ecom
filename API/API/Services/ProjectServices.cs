using API.Models;
using Microsoft.EntityFrameworkCore;
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
        public Products GetProductByID(int ID) => _context.Products.FirstOrDefault(x => x.ID == ID);
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

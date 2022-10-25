using API.Models;
using Microsoft.EntityFrameworkCore;

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
        public void AddProduct(Products products) {
            var _product = new Products();

            _product.ID = products.ID;
            _product.Name = products.Name;
            _product.Number = products.Number;
            _product.Price = products.Price;
           

            _context.Products.Add(_product);
            _context.SaveChanges();
        }

    }
}

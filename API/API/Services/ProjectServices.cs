using API.Models;

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


        public Products GetProductById(int id) => _context.Products.FirstOrDefault(x => x.ID == id);

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

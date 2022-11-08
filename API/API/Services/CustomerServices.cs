using API.Models;

namespace API.Services
{
    public class CustomerServices
    {
        private ShopDbContext _context;
        public CustomerServices(ShopDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers() => _context.Customers.ToList();
        public Customer GetCustomerByID(int ID) => _context.Customers.Where(c => c.ID == ID).FirstOrDefault();
    }
}

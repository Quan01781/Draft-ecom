using API.Models;
using API.Interfaces;

namespace API.Services
{
    public class CustomerServices : ICustomerService
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

using API.Models;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel.DTO;


namespace API.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerByID(int ID);
    }
}

using API.Models;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel.DTO;


namespace API.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<AdminCategoryDTO> AddCategory(AdminCategoryDTO addcategory);
        Task<AdminCategoryDTO> UpdateCategory(AdminCategoryDTO updatecategory, int ID);
        int DeleteCategory(int ID);
        Category GetCategoryByID(int ID);
        List<Products> GetProductByCategory(int ID);
    }
}

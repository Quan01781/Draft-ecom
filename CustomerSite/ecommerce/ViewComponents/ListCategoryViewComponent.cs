using CustomerSite.Clients;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel.DTO;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CustomerSite.ViewComponents
{
    public class ListCategoryViewComponent : ViewComponent
    {
        private readonly IProductClient _category;
        public ListCategoryViewComponent(IProductClient category)
        {
            _category = category;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            return View(categories);
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {

            var data = await _category.GetAllCategories();
            return data;


        }
    }
}

using CustomerSite.Clients;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel.DTO;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CustomerSite.ViewComponents
{ 
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductClient _category;
        public ProductViewComponent(IProductClient category) 
        {
            _category = category;
        }

        public async Task<IViewComponentResult> InvokeAsync(int page=1, int pageSize = 9) 
        {
            var products = await GetProductsAsync(page, pageSize);
            return View(products);
        }

        public async Task<List<ProductsDTO>> GetProductsAsync(int page = 1, int pageSize = 9)
        {
            
            var data = await _category.GetAllProduct();
            return data;

            
        }
    }
}

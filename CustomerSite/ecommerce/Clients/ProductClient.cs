using Newtonsoft.Json;
using ShareViewModel.DTO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomerSite.Clients
{
    public interface IProductClient
    {
        Task<List<ProductsDTO>> GetAllProduct();
    }

    public class ProductClient : BaseClient, IProductClient
    {
        //public ProductClient(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(clientFactory, httpContextAccessor)
        //{

        //}

        public ProductClient(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<List<ProductsDTO>> GetAllProduct()
        {
            var response = await httpClient.GetAsync("api/product/get-all-products");
            var contents = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<List<ProductsDTO>>(contents);

            return products ?? new List<ProductsDTO>();
        }

        
    }
}

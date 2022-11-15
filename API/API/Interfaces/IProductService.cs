using API.Models;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel.DTO;


namespace API.Interfaces
{
    public interface IProductService
    {
        List<Products> GetAllProductsByAdmin();
        List<ProductsDTO> GetAllProducts();
        ProductsDTO GetProductByID(int ID);
        Products GetProductByIDAdmin(int ID);
        Products AddProduct(AdminProductDTO addproduct);
        string UploadFile(ImageDTO file);
        Products UpdateProduct(AdminProductDTO updateproduct, int ID);
        int DeleteProduct(int ID);
        List<Products> GetProductBySearchAdmin(string searchstring);
        List<ProductsDTO> GetProductBySearch(string searchstring);
    }
}

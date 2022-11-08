
namespace ShareViewModel.DTO
{
    public class AdminProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Created_by { get; set; }
    }
}
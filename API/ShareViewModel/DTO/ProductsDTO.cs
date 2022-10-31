
namespace ShareViewModel.DTO
{
    public class ProductsDTO
    {
        public int ID { get; set; }
   
        public string Name { get; set; }
  
        public int Quantity { get; set; }
  
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

        public ICollection<RatingDTO> Ratings { get; set; }
    }
}

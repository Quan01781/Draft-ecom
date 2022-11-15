using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Created_by { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}

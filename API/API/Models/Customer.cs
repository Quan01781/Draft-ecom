using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone  { get; set; }
        public DateTime? Created_at { get; set; }
    }
}

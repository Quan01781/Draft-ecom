using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public int Star { get; set; }
        public string Content { get; set; }
        public int ProductID { get; set; }
        public DateTime? Created_at { get; set; }
        [ForeignKey("ProductID")]
        public Products Product { get; set; }
    }
}
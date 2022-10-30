using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public int Star { get; set; }
        public string Message { get; set; } = "";
        public DateTime CreateDate { get; set; }
        public Products Product { get; set; }
    }
}
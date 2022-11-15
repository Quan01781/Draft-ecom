using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Products
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }     
        public int? CategoryID { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string? Created_by { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}

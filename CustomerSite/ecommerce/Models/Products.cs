using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace ecommerce.Models
{
    public class Products
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Img { get; set; }
        public int? Created_by { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_At { get; set; }

    }
}

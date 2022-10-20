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
        public int Number { get; set; }
        [Required]
        public double Price { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}

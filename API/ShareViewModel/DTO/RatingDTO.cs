using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareViewModel.DTO
{
    public class RatingDTO
    {
        public int ID { get; set; }
        public int Star { get; set; }
        public string Content { get; set; }
        public int ProductID { get; set; }
        public DateTime? Created_at { get; set; }       
    }
}

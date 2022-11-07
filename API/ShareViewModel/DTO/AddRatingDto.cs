using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareViewModel.DTO
{
    public class AddRatingDto
    {
        public int Star { get; set; }
        public string Content { get; set; } = "";
        public int ProductID { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareViewModel.DTO
{
	public class ImageDTO
	{
		public string FileName { get; set; }
		public IFormFile FormFile{ get; set; }
	}
}

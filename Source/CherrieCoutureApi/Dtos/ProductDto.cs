using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CherrieCoutureApi.EnumDto;
using MongoDB.Bson;

namespace CherrieCoutureApi.Dtos
{
	public class ProductDto
	{
		public string Id { get; set; }
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		public string Size { get; set; }
		public CategoryEnumDto Category { get; set; }
		public int StockQuantity { get; set; }
	}
}

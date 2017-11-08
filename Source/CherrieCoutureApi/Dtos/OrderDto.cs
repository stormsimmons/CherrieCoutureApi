using CherrieCoutureApi.EnumDto;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherrieCoutureApi.Dtos
{
	public class OrderDto
	{
		public string Id { get; set; }
		public string CustomerId { get; set; }
		public List<ProductDto> ProductList { get; set; }
		public decimal TotalPrice { get; set; }
		public OrderEnumDto Status { get; set; }
	}
}

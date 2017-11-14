using CherrieCoutureApi.Dtos;
using CherrieCoutureApi.EnumDto;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CherrieCoutureApi.Requests.Order
{
	public class UpdateOrderRequest
	{
		public string CustomerId { get; set; }
		public string UserName { get; set; }

		public List<ProductDto> ProductList { get; set; }
		public decimal TotalPrice { get; set; }
		public OrderEnumDto Status { get; set; }
	}
}

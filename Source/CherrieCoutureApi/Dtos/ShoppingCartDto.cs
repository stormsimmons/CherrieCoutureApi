using MongoDB.Bson;
using System.Collections.Generic;

namespace CherrieCoutureApi.Dtos
{
    public class ShoppingCartDto
    {
		public string Id { get; set; }
		public string UserId { get; set; }
		public string UserName { get; set; }
		public IList<ProductDto> ProductList { get; set; }
	}
}

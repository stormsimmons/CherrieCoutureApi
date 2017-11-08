using CherrieCoutureApi.EnumDto;

namespace CherrieCoutureApi.Requests.Product
{
	public class AddProductRequest
	{
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

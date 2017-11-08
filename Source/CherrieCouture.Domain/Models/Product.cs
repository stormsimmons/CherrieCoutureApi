using CherrieCouture.Domain.Enums;
using MongoDB.Bson;

namespace CherrieCouture.Domain.Models
{
	public class Product
	{
		public ObjectId Id { get; set; }
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		public string Size { get; set; }
		public CategoryEnum Category { get; set; }
		public int StockQuantity { get; set; }
	}
}
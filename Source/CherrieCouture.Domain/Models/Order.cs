using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CherrieCouture.Domain.Enums;
using MongoDB.Bson;

namespace CherrieCouture.Domain.Models
{
	public class Order
	{
		public ObjectId Id { get; set; }
		public ObjectId CustomerId { get; set; }
		public List<Product> ProductList { get; set; }
		public decimal TotalPrice { get; set; }
		public OrderEnum Status { get; set; }
	}
}

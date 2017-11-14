using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherrieCouture.Domain.Models
{
    public class ShoppingCart
    {
	
		public ObjectId Id{ get; set; }
		public ObjectId UserId { get; set; }
		public string UserName { get; set; }
		public IList<Product> ProductList { get; set; }
	}
}

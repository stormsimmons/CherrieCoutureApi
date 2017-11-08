using CherrieCouture.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherrieCouture.Domain.Interfaces
{
	public interface IProductRepository
	{
		IList<Product> List();
		Product GetProduct(string productId);
		void Insert(Product product);

		void Delete(Product product);
		void Update(Product product);
	}
}

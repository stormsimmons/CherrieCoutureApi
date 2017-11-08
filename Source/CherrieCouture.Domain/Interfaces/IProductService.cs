using CherrieCouture.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherrieCouture.Domain.Interfaces
{
	public interface IProductService
	{
		void AddProduct(Product product);
		IList<Product> GetProductList();
		Product GetOneProductById(string id);
		void UpdateProductDetails(Product product);
		void DeleteProduct(Product product);
	}
}

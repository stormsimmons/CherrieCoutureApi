using CherrieCouture.Domain.Interfaces;
using System.Collections.Generic;
using CherrieCouture.Domain.Models;
using MongoDB.Bson;

namespace CherrieCouture.Domain.Service
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepo;
		public ProductService(IProductRepository productRepository)
		{
			_productRepo = productRepository;
		}
		public void AddProduct(Product product)
		{
			_productRepo.Insert(product);
		}

		public void DeleteProduct(Product product)
		{
			_productRepo.Delete(product);
		}

		public Product GetOneProductById(string id)
		{
			return _productRepo.GetProduct(id);
		}

		public IList<Product> GetProductList()
		{
			return _productRepo.List();
		}

		public void UpdateProductDetails(Product product)
		{
			_productRepo.Update(product);
		}
	}
}

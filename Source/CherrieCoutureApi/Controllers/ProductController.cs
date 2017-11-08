using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CherrieCouture.Domain.Interfaces;
using CherrieCoutureApi.Dtos;
using CherrieCoutureApi.Requests.Product;
using AutoMapper;
using CherrieCouture.Domain.Models;
using CherrieCouture.Domain.Enums;
using MongoDB.Bson;

namespace CherrieCoutureApi.Controllers
{
    [Produces("application/json")]
    [Route("product")]
    public class ProductController : Controller
    {
		private IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[Route("list")]
		[HttpGet]
		public List<ProductDto> Get(ProductListRequest request)
		{
			var list = _productService.GetProductList();

			var mappedList = Mapper.Map<List<ProductDto>>(list);

			return mappedList;
		}
		[Route("add")]
		[HttpPost]
		public void Any([FromBody]AddProductRequest request)
		{
			var product = new Product
			{
				ProductId = request.ProductId,
				Name = request.Name,
				Price = request.Price,
				Size = request.Size,
				Description = request.Description,
				ImageUrl = request.ImageUrl,
				Category = (CategoryEnum)request.Category,
				StockQuantity = request.StockQuantity
			};

			_productService.AddProduct(product);
		}
		[Route("update")]
		[HttpPost]
		public void Any([FromBody]UpdateProductRequest request)
		{
			var product = new Product
			{
				Id = ObjectId.Parse(request.Id),
				ProductId = request.ProductId,
				Name = request.Name,
				Description = request.Description,
				Category = (CategoryEnum)request.Category,
				ImageUrl = request.ImageUrl,
				Price = request.Price,
				Size = request.Size,
				StockQuantity = request.StockQuantity
			};

			_productService.UpdateProductDetails(product);
		}
		[Route("delete")]
		[HttpPost]
		public void Any([FromBody]DeleteProductRequest request)
		{
			var product = _productService.GetOneProductById(request.Id);
			_productService.DeleteProduct(product);
		}

		[Route("getproduct")]
		[HttpGet]
		public ProductDto Any(GetOneProductRequest request)
		{
			var product = _productService.GetOneProductById(request.Id);
			return Mapper.Map<ProductDto>(product);

			
		}
	}
}
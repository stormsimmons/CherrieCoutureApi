using Microsoft.AspNetCore.Mvc;
using CherrieCouture.Domain.Interfaces;
using CherrieCoutureApi.Dtos;
using CherrieCoutureApi.Requests.User;
using AutoMapper;
using CherrieCouture.Domain.Models;
using MongoDB.Bson;
using CherrieCouture.Domain.Enums;
using CherrieCoutureApi.Requests.ShoppingCart;

namespace CherrieCoutureApi.Controllers
{
    [Produces("application/json")]
    [Route("shoppingcart")]
    public class ShoppingCartController : Controller
    {
		private readonly IShoppingCartService _shoppingCartService;
		private readonly IProductService _productService;
		public ShoppingCartController(IShoppingCartService shoppingCartService, IProductService productService)
		{
			_shoppingCartService = shoppingCartService;
			_productService = productService;
		}
		[Route("getcart")]
		[HttpGet]
		public ShoppingCartDto Get([FromQuery]GetCartRequest request)
		{
			var cart = _shoppingCartService.GetCart(request.UserName);

			var cartDto = Mapper.Map<ShoppingCartDto>(cart);
			return cartDto;
		}
		[Route("removeitem")]
		[HttpGet]
		public void Get([FromQuery]DeleteItemRequest request)
		{
			var product = _productService.GetOneProductById(request.ProductId);
			_shoppingCartService.DeleteProduct(request.UserName, product);
		}

		[Route("addtocart")]
		[HttpPost]
		public void Post([FromBody] AddToCartRequest request)
		{
			var product = new Product
			{
				Id = ObjectId.Parse(request.product.Id),
				ProductId = request.product.ProductId,
				Name = request.product.Name,
				Category = (CategoryEnum)request.product.Category,
				Description = request.product.Description,
				ImageUrl = request.product.ImageUrl,
				Price = request.product.Price,
				Size = request.product.Size,
				StockQuantity = request.product.StockQuantity
			};
			_shoppingCartService.AddToCart(request.UserName, product);
		}

	
	}
}
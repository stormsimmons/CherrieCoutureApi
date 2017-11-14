using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CherrieCouture.Domain.Interfaces;
using CherrieCoutureApi.Requests.Order;
using CherrieCoutureApi.Dtos;
using AutoMapper;
using CherrieCouture.Domain.Models;
using CherrieCouture.Domain.Enums;
using MongoDB.Bson;

namespace CherrieCoutureApi.Controllers
{
    [Produces("application/json")]
    [Route("order")]
    public class OrderController : Controller
    {

		private IOrderService _orderService;
		private IShoppingCartService _shoppingCartService;
		public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService)
		{
			_orderService = orderService;
			_shoppingCartService = shoppingCartService;
		}

		[Route("list")]
		[HttpGet]
		public List<OrderDto> Get(ListOrderRequest request)
		{
			var list = _orderService.GetAllOrders();
			var dtoList = Mapper.Map<List<OrderDto>>(list);
			return dtoList;
		}

		[Route("add")]
		[HttpPost]
		public void Post([FromBody]AddOrderRequest request)
		{
			var orderToAdd = new OrderDto
			{
				CustomerId = request.CustomerId,
				UserName = request.UserName,
				ProductList = request.ProductList,
				TotalPrice = request.TotalPrice,
				Status = request.Status
			};

			var mappedOrder = Mapper.Map<Order>(orderToAdd);

			_orderService.AddAnOrder(mappedOrder);
			_shoppingCartService.EmptyCart(mappedOrder.UserName);
			
		}

		[Route("update")]
		[HttpPost]
		public void Any([FromBody]UpdateOrderRequest request)
		{
			var orderToUpdate = new Order
			{
				CustomerId = ObjectId.Parse(request.CustomerId),
				UserName = request.UserName,
				ProductList = Mapper.Map<List<Product>>(request.ProductList),
				TotalPrice = request.TotalPrice,
				Status = Mapper.Map<OrderEnum>(request.Status)
			};

			_orderService.UpdateOrderDetails(orderToUpdate);

		}

	}
}
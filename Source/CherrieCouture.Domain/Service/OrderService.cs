﻿using CherrieCouture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CherrieCouture.Domain.Models;
using MongoDB.Bson;

namespace CherrieCouture.Domain.Service
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepo;
		private readonly IUserService _userService;
		private readonly IShoppingCartService _shoppingCartService;
		public OrderService(IOrderRepository orderRepository, IUserService userService, IShoppingCartService shoppingCartService)
		{
			_orderRepo = orderRepository;
			_userService = userService;
			_shoppingCartService = shoppingCartService;
		}
		public void AddAnOrder(Order order)
		{
			var userlist = _userService.GetUserList();
			var user = userlist.FirstOrDefault(x => x.Id == order.CustomerId);
			_orderRepo.Insert(order);
			_shoppingCartService.EmptyCart(user.UserName);
		}

		public void DeleteOrder(Order order)
		{
			_orderRepo.Delete(order);
		}

		public IList<Order> GetAllOrders()
		{
			return _orderRepo.List();
		}

		public Order GetOneOrderById(string id)
		{
			return _orderRepo.GetOrder(id);
		}

		public void UpdateOrderDetails(Order order)
		{
			_orderRepo.Update(order);
		}
	}
}

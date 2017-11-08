using CherrieCouture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CherrieCouture.Domain.Models;
using MongoDB.Bson;

namespace CherrieCouture.Domain.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepo;
		private readonly IOrderRepository _orderRepo;
		public UserService(IUserRepository userRepository, IOrderRepository orderRepository)
		{
			_userRepo = userRepository;
			_orderRepo = orderRepository;
		}

		public void DeleteUser(User user)
		{
			_userRepo.Delete(user);
		}

		public User GetOneUserByUserName(string userName)
		{
			return _userRepo.GetUser(userName);
		}

		public IList<Order> GetOrdersByUser(string customerId)
		{
			var orderlist = _orderRepo.List().ToList();
			List<Order> orders = orderlist.FindAll(x => x.CustomerId.ToString() == customerId);
			return orders;
		}

		public IList<User> GetUserList()
		{
			return _userRepo.List();
		}

		public void UpdateUserDetails(User user)
		{
			_userRepo.Update(user);
		}

		//public void EmptyShopingCart(string userName)
		//{
		//	var user = GetOneUserByUserName(userName);
		//	user.ShppongCart = new List<Product>();
		//	UpdateUserDetails(user);
		//}
	}
}

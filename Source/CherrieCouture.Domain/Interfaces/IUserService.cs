using CherrieCouture.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherrieCouture.Domain.Interfaces
{
	public interface IUserService
	{
		IList<User> GetUserList();
		User GetOneUserByUserName(string userName);
		void UpdateUserDetails(User user);
		void DeleteUser(User user);
		//void EmptyShopingCart(string userName);

		IList<Order> GetOrdersByUser(string customerId);

	}
}

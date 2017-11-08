using CherrieCouture.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherrieCouture.Domain.Interfaces
{
	public interface IOrderService
	{
		IList<Order> GetAllOrders();
		Order GetOneOrderById(string id);
		void AddAnOrder(Order order);
		void UpdateOrderDetails(Order order);
		void DeleteOrder(Order order);
	}
}

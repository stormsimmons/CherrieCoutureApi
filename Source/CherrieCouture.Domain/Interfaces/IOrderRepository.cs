using CherrieCouture.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherrieCouture.Domain.Interfaces
{
	public interface IOrderRepository
	{
		IList<Order> List();
		Order GetOrder(string orderId);
		void Insert(Order order);

		void Delete(Order order);
		void Update(Order order); 
	}
}

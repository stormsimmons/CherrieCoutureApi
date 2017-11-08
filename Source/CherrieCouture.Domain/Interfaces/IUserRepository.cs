using CherrieCouture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherrieCouture.Domain.Interfaces
{
	public interface IUserRepository
	{
		IList<User> List();
		User GetUser(string userName);
		void Insert(User user);
		void Delete(User user);
		void Update(User user);
	}
}

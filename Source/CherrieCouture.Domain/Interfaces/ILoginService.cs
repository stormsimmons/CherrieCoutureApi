using CherrieCouture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherrieCouture.Domain.Interfaces
{
	public interface ILoginService
	{
		User ValidateUserCredentials(string userName, string password);
		void RegisterUser(User user);
	}
}

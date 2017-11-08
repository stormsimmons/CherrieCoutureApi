using CherrieCoutureApi.Dtos;
using System.Collections.Generic;

namespace CherrieCoutureApi.Requests.Login
{
	public class RegisterRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}

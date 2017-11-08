using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CherrieCoutureApi.Requests.Login
{
	public class LoginValidationRequest
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}

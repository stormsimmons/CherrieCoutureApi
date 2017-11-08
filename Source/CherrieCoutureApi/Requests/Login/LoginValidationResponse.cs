using CherrieCoutureApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherrieCoutureApi.Requests.Login
{
	public class LoginValidationResponse
	{
		public UserDto LoggedOnUser { get; set; }
		public bool ValidCredentials { get; set; }
	}
}

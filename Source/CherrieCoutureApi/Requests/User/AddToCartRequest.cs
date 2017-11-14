using CherrieCoutureApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CherrieCoutureApi.Requests.User
{
    public class AddToCartRequest
    {
		public string UserName { get; set; }
		public ProductDto product { get; set; }
	}
}

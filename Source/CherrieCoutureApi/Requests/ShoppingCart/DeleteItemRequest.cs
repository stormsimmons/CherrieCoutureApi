using CherrieCoutureApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CherrieCoutureApi.Requests.ShoppingCart
{
    public class DeleteItemRequest
    {
		public string UserName { get; set; }
		public string ProductId { get; set; }
	}
}

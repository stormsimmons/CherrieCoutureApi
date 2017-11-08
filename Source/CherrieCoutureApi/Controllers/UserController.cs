using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CherrieCouture.Domain.Interfaces;
using CherrieCoutureApi.Requests.User;
using CherrieCoutureApi.Dtos;
using AutoMapper;
using CherrieCouture.Domain.Models;

namespace CherrieCoutureApi.Controllers
{
    [Produces("application/json")]
    [Route("user")]
    public class UserController : Controller
    {
		private IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		[Route("list")]
		[HttpGet]
		public List<UserDto> Get(ListUserRequest request)
		{
			var list = _userService.GetUserList().ToList();

			var mappedList = Mapper.Map<List<UserDto>>(list);

			return mappedList;
		}

		[Route("getuser")]
		[HttpGet]
		public UserDto Get([FromQuery]string UserName)
		{
			var user = _userService.GetOneUserByUserName(UserName);

			var mappedUser = Mapper.Map<UserDto>(user);

			return mappedUser;
		}

		[Route("delete")]
		[HttpPost]
		public void Post([FromBody]DeleteUserRequest request)
		{
			var userToDelete = _userService.GetOneUserByUserName(request.UserName);
			_userService.DeleteUser(userToDelete);

		}
		[Route("update")]
		[HttpPost]
		public void Post([FromBody] UpdateUserRequest request)
		{
			var user = new User
			{
				UserName = request.UserName,
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				Password = request.Password,
			};

			_userService.UpdateUserDetails(user);
		}
		[Route("orderlist")]
		[HttpGet]
		public List<OrderDto> Get(UserOrderListRequest request)
		{
			var list = _userService.GetOrdersByUser(request.CustomerId);

			var mappedList = Mapper.Map<List<OrderDto>>(list);

			return mappedList;

		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CherrieCoutureApi.Requests.Login;
using CherrieCouture.Domain.Interfaces;
using CherrieCoutureApi.Dtos;
using AutoMapper;
using CherrieCouture.Domain.Models;

namespace CherrieCoutureApi.Controllers
{
    [Produces("application/json")]
    [Route("login")]
    public class LoginController : Controller
    {
		private readonly ILoginService _loginService;
		public LoginController(ILoginService loginService)
		{
			_loginService = loginService;
		}

		[HttpPost]
		[Route("validate")]

		public LoginValidationResponse Post([FromBody] LoginValidationRequest request)
		{

			var validUser = _loginService.ValidateUserCredentials(request.UserName, request.Password);
			var userMapped = Mapper.Map<UserDto>(validUser);

			var response = new LoginValidationResponse();

			if (validUser == null)
			{
				response.ValidCredentials = false;
				response.LoggedOnUser = null;
			}
			else
			{
				response.LoggedOnUser = Mapper.Map<UserDto>(validUser);
				response.ValidCredentials = true;
			}

			return response;
		}

		[HttpPost]
		[Route("register")]
		public void Post([FromBody]RegisterRequest request)
		{
			UserDto incommingUser = new UserDto
			{

				FirstName = request.FirstName,
				LastName = request.LastName,
				UserName = request.UserName,
				Email = request.Email,
				Password = request.Password,
			};

			var user = Mapper.Map<User>(incommingUser);
			_loginService.RegisterUser(user);

		}
	}
}
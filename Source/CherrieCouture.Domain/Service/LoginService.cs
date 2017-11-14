using CherrieCouture.Domain.Interfaces;

using CherrieCouture.Domain.Models;
using System.Collections.Generic;

namespace CherrieCouture.Domain.Service
{
	public class LoginService : ILoginService
	{
		private IUserRepository _userRepo;
		private readonly IShoppingCartRepository _shoppingCartRepository;
		public LoginService(IUserRepository userRepository, IShoppingCartRepository shoppingCartRepository)
		{
			_userRepo = userRepository;
			_shoppingCartRepository = shoppingCartRepository;
		}
		public void RegisterUser(User user)
		{
			_userRepo.Insert(user);
			var dbUser = _userRepo.GetUser(user.UserName);
			var userCart = new ShoppingCart
			{
				UserId = dbUser.Id,
				ProductList = new List<Product>(),
				UserName = dbUser.UserName
			};
			_shoppingCartRepository.Insert(userCart);
		}
		/// <summary>
		/// If Null is returned either the username or password is inccorect 
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public User ValidateUserCredentials(string userName, string password)
		{

			User user = _userRepo.GetUser(userName);

			if (user != null)
			{
				if (password == user.Password)
				{
					return user;
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
		}
	}
}

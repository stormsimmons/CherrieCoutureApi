using CherrieCouture.Domain.Interfaces;

using CherrieCouture.Domain.Models;

namespace CherrieCouture.Domain.Service
{
	public class LoginService : ILoginService
	{
		private IUserRepository _userRepo;
		public LoginService(IUserRepository userRepository)
		{
			_userRepo = userRepository;
		}
		public void RegisterUser(User user)
		{
			_userRepo.Insert(user);
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

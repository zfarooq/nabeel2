using System.Collections.Generic;
using System.Linq;
using Client.WebAPI.Models;
namespace Client.WebAPI.Helper
{
	public static class ExtensionMethods
	{
		public static IEnumerable<UserModel> WithoutPasswords(this IEnumerable<UserModel> users)
		{
			return users.Select(x => x.WithoutPassword());
		}
		public static UserModel WithoutPassword(this UserModel user)
		{
			user.Password = null;
			return user;
		}
	}
}

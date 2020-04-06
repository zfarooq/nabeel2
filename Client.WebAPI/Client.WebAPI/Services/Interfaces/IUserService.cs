using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.WebAPI.Models;
namespace Client.WebAPI.Services
{
	public interface IUserService
	{
		Task<UserModel> Authenticate(string username, string password);
		Task<IList<UserModel>> GetAll();
		Task< UserModel> Add(UserModel userModel);
		Task Delete(int Id);
		Task<UserModel> Update(UserModel userModel);
	}
}

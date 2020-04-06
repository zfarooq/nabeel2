using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.WebAPI.Entities;
namespace Client.WebAPI.Repositories
{
	public interface IUserRepository
	{
		Task<IList<User>> GetAll();
		Task<User> GetUserByUserName(string userName, string password);
		Task<User> GetById(int Id);
		Task<User> Add(User user);
		Task<User> Update(User user);
		Task Delete(int Id);
	}
}

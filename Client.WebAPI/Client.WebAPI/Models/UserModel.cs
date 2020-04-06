using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.WebAPI.Models
{
	public class UserModel : TrackableModel<int>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }
		public Nullable<int> RoleId { get; set; }
		public virtual RoleModel RoleModel { get; set; }
	}
}

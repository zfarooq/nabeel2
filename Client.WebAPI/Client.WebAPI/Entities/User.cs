using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.WebAPI.Entities
{
	public class User:TrackableEntityBase<int>
	{	
		public User()
		{
			Role = new Role();
		}
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public Nullable<int> RoleId { get; set; }
		public virtual Role Role { get; set; }
	}
}

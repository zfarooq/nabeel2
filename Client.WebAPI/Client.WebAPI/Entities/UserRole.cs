using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.WebAPI.Entities
{
	public class UserRole:KeyedEntityBase<int>
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
	}
}

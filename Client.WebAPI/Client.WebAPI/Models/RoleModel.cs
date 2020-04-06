using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.WebAPI.Models
{
	public class RoleModel : TrackableModel<int>
	{
		public string  Name { get; set; }
		public string Description{ get; set; }
	}
}

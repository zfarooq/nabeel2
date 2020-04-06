using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.WebAPI.Models
{
	public class ClientModel: TrackableModel<int>
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ContactPhone { get; set; }
		public string ContactEmail { get; set; }
		public string Logo { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.WebAPI.Entities
{
	public abstract class KeyedEntityBase<TValue>
	{
		public TValue Id { get; set; }
	}
}

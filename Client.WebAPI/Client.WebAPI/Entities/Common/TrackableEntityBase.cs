using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.WebAPI.Entities
{
	public abstract class TrackableEntityBase<TId> : KeyedEntityBase<TId>
	{
		public Nullable<int> CreatedBy { get; set; }
		public Nullable<DateTime> CreatedOn { get; set; }
		public Nullable<int> ModifiedBy { get; set; }
		public Nullable<DateTime> ModifiedOn { get; set; }
	}
}

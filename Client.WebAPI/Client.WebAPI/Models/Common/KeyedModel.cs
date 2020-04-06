using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.WebAPI.Models
{
	public class KeyedModel<T> where T : IEquatable<T>
	{
		public T Id { get; set; }
	}
}

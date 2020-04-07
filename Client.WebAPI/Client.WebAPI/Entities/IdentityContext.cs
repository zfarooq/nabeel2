using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.WebAPI.Entities
{
	public class IdentityContext: IdentityDbContext<IdentityUser, IdentityRole, int>
	{
		public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
		{
		}
	}
}

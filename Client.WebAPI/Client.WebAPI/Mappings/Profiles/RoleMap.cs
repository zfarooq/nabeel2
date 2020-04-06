using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Client.WebAPI.Entities;
using Client.WebAPI.Models;
namespace Client.WebAPI.Mappings
{
	public class RoleMap : Profile
	{
		public RoleMap()
		{
			CreateMap<Role, RoleModel>();
			CreateMap<RoleModel, Role>();
		}
	}
}

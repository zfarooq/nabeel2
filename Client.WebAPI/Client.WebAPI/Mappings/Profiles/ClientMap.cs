using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Client.WebAPI.Entities;
using Client.WebAPI.Models;
namespace Client.WebAPI.Mappings
{
	public class ClientMap: Profile
	{
		public ClientMap()
		{
			CreateMap<Entities.Client, ClientModel>();
			CreateMap<ClientModel, Entities.Client>();
		}
	}
}

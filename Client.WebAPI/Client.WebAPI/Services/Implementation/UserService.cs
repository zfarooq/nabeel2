using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.WebAPI.Helper;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Client.WebAPI.Repositories;
using Client.WebAPI.Models;
using System.Text;
using AutoMapper;

namespace Client.WebAPI.Services
{
	public class UserService : IUserService
	{
		private readonly AppSettings _appSettings;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		public UserService(IOptions<AppSettings> appSettings,
			IUserRepository userRepository,
			IMapper mapper)
		{
			_appSettings = appSettings.Value;
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<UserModel> Add(UserModel userModel)
		{
			var user = _mapper.Map<Entities.User>(userModel);
			user = await _userRepository.Add(user);
			
			return userModel;
		}

		public async Task<UserModel> Authenticate(string username, string password)
		{
			var user = await _userRepository.GetUserByUserName(username, password);
			var userModel = this._mapper.Map<UserModel>(user);
			if (userModel == null)
			{
				return null;
			}
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			userModel.Token = tokenHandler.WriteToken(token);
			return userModel.WithoutPassword();
		}

		public async Task Delete(int Id)
		{
			await this._userRepository.Delete(Id);
		}

		public async Task<IList<UserModel>> GetAll()
		{
			var users = await _userRepository.GetAll();
			return this._mapper.Map<List<UserModel>>(users);
		}

		public async Task<UserModel> Update(UserModel userModel)
		{
			var user = _mapper.Map<Entities.User>(userModel);
			await _userRepository.Update(user);
			return userModel;
		}
	}
}

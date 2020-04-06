using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Client.WebAPI.Services;
using Client.WebAPI.Models;
namespace Client.WebAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
		private readonly IUserService _userService;
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}
		[AllowAnonymous]
		[HttpPost("authenticate")]
		public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
		{
			var user = await _userService.Authenticate(model.Username, model.Password);
			if (user == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			return Ok(user);
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var users = await _userService.GetAll();
			return Ok(users);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] UserModel userModel)
		{
			var result = await _userService.Add(userModel);
			return Ok(result);
		}
		[Route("{id:int}")]
		[HttpDelete]
		public async Task<IActionResult> Delete(int Id)
		{
			await _userService.Delete(Id);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UserModel userModel)
		{
			var result = await _userService.Update(userModel);
			return Ok(userModel);
		}

	}
}
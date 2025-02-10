using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using webapi.Mappers;
using webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{

		private readonly IUserRepository<User> _userService;

		public UserController(IUserRepository<User> userService)
		{
			_userService = userService;
		}
		// GET: api/<UserrController>
		[HttpGet]
		[ProducesResponseType<IEnumerable<UserDTO>>(200)]
		[ProducesResponseType(500)]
		public IActionResult Get()
		{
			try
			{

				IEnumerable<UserDTO> model = _userService.Get().Select(user => user.ToDTO());
				return Ok(model); // Return the list of UserDTOs
			}
			catch (SqlException)
			{
				return StatusCode(500); // Return 500 Internal Server Error in case of a SQL exception

			}
		}

		// GET api/<UserrController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<UserrController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<UserrController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UserrController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}

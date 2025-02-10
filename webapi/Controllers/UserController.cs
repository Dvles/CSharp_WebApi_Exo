using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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
		public IEnumerable<string> Get()
		{
			try
			{
				IEnumerable<UserDTO> model = _userService(Get).Select(BLL => BLL.ToDTO());
				return new string[] { "value1", "value2" };
			}
			catch (SqlException)
			{
				return StatusCode(500);
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

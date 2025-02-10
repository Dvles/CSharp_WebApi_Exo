using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;

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
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
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

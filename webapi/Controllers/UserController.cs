using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
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
		// GET: api/<UserController>
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

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		[ProducesResponseType<UserDTO>(200)]
		[ProducesResponseType(404)]
		public ActionResult<UserDTO> Get(Guid id)
		{
			User user = _userService.Get(id);

			if (user == null)
			{
				return NotFound();
			}


			return Ok(user.ToDTO());
		}


		// POST api/<UserController>
		[HttpPost]
		[ProducesResponseType<UserDTO>(201)]
		public IActionResult Post([FromBody] UserPostDTO value)
		{
			try
			{
				Guid id = _userService.Insert(value.ToBLL());
				UserDTO model = _userService.Get(id).ToDTO();
				return CreatedAtAction(nameof(Get), new { id }, model);

			}
			catch
			{
				return StatusCode();
			}

		}


		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}

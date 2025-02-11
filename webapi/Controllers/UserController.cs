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
		[ProducesResponseType<User>(201)]
		public IActionResult Insert(User user)
		{
			try
			{
				if (user == null)
				{
					return BadRequest("User data is required.");
				}

				Console.WriteLine($"Received user: {user.First_Name} {user.Last_Name}");

				Guid id = _userService.Insert(user); // Call service
				Console.WriteLine($"Inserted User ID: {id}");

				user.User_Id = id; // Assign ID to user

				return CreatedAtAction(nameof(Get), new { id }, user);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
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

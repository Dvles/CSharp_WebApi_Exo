using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DemoController : ControllerBase
	{
		public IActionResult TestApi()
		{
			return Ok();
		}
	}
}

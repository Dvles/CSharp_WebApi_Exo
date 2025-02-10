using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DemoController : ControllerBase
	{
		private static List<string> _list = new List<string>
		{
			"Charifa", "Khaoula", "Mélusine", "Dorothée", "Jenny", "Marwa", "Anaïs", "Emilie", "Amalia", "Leslie", "Debby"
		};
		
		[HttpGet("")]
		public ActionResult<List<string>> Get()
		{
			List<string> model = _list;
			return Ok(model);
		}
	}
}

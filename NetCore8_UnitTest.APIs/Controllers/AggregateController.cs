using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCore8_UnitTest.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AggregateController : ControllerBase
	{
		[HttpGet]
		public ActionResult<int> Sum(int a, int b)
		{
			return Ok(a + b);
		}
	}
}

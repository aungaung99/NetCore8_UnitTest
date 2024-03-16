using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NetCore8_UnitTest.APIs.Data;
using NetCore8_UnitTest.APIs.Entities;

namespace NetCore8_UnitTest.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatesController(NetCoreDemoDbContext context) : ControllerBase
	{
		private readonly NetCoreDemoDbContext _context = context;

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _context.States.ToListAsync());
		}

		[HttpGet("/{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			State? state = await _context.States.FirstOrDefaultAsync(x => x.StateId == id);
			return state != null ? Ok(state) : NotFound();
		}
	}
}

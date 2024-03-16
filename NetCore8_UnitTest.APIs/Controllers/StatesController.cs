using Microsoft.AspNetCore.Mvc;

using NetCore8_UnitTest.APIs.Entities;
using NetCore8_UnitTest.APIs.Interfaces;

namespace NetCore8_UnitTest.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatesController(IRepositoryWrapper repository) : ControllerBase
	{
		private readonly IRepositoryWrapper _repository = repository;

		[HttpGet]
		public async Task<ActionResult<IReadOnlyList<State>?>> GetListAsync()
		{
			IReadOnlyList<State>? list = await _repository.States.GetAsync();
			return list?.Count > 0 ? Ok(list) : NotFound();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<State?>> GetByIdAsync(int id)
		{
			State? state = await _repository.States.GetByIdAsync(id);
			return state != null ? Ok(state) : NotFound("Not found");
		}
	}
}

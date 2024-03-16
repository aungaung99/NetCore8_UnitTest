using NetCore8_UnitTest.APIs.Data;
using NetCore8_UnitTest.APIs.Entities;
using NetCore8_UnitTest.APIs.Interfaces;

namespace NetCore8_UnitTest.APIs.Services.Base
{
	public class StateRepo(NetCoreDemoDbContext context) : RepositoryBase<State>(context), IStateRepo
	{
		private readonly NetCoreDemoDbContext _context = context;
	}
}

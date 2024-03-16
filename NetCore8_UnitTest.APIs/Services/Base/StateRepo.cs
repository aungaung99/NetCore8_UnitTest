using NetCore8_UnitTest.APIs.Data;
using NetCore8_UnitTest.APIs.Entities;
using NetCore8_UnitTest.APIs.Interfaces;

namespace NetCore8_UnitTest.APIs.Services.Base
{
	public class StateRepo : RepositoryBase<State>, IStateRepo
	{
		private readonly NetCoreDemoDbContext _context;
		public StateRepo(NetCoreDemoDbContext context) : base(context)
		{
			_context = context;
		}
	}
}

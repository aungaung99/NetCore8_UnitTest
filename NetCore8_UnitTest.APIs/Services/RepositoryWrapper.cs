using Microsoft.EntityFrameworkCore.Storage;

using NetCore8_UnitTest.APIs.Data;
using NetCore8_UnitTest.APIs.Interfaces;
using NetCore8_UnitTest.APIs.Services.Base;

namespace NetCore8_UnitTest.APIs.Services
{
	public class RepositoryWrapper(NetCoreDemoDbContext context) : IRepositoryWrapper
	{
		private readonly NetCoreDemoDbContext _context = context;

		// Tables
		private IStateRepo? _states;

		public IStateRepo States
		{
			get { _states ??= new StateRepo(_context); return _states; }
		}


		// Db Action without Async
		public void Save() => _ = _context.SaveChanges();

		// Db Action with Async
		public async Task<bool> SaveAsync()
		{
			try
			{
				return await _context.SaveChangesAsync() > 0;
			}
			catch
			{
				return false;
			}
		}

		public IDbContextTransaction TransactionBegin() => _context.Database.BeginTransaction();

		public async Task<IDbContextTransaction> TransactionBeginAsync() => await _context.Database.BeginTransactionAsync();
	}
}

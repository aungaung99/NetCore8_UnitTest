using Microsoft.EntityFrameworkCore.Storage;

namespace NetCore8_UnitTest.APIs.Interfaces
{
	public interface IRepositoryWrapper
	{
		IStateRepo States { get; }

		// Method
		void Save();
		Task<bool> SaveAsync();
		IDbContextTransaction TransactionBegin();
		Task<IDbContextTransaction> TransactionBeginAsync();
	}
}

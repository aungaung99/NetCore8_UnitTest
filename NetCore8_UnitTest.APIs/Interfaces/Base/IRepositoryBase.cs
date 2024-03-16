using System.Linq.Expressions;

namespace NetCore8_UnitTest.APIs.Interfaces.Base
{
	public interface IRepositoryBase<T>
	{
		IQueryable<T> FindAll { get; }
		IQueryable<T> FindByConditions(Expression<Func<T, bool>> conditionExpression);
		IReadOnlyList<T>? Get();
		Task<IReadOnlyList<T>?> GetAsync();
		Task<IReadOnlyList<T>?> GetAsync(Expression<Func<T, bool>> predicate);
		Task<IReadOnlyList<T>?> GetAsync(
			Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			string? includeString = null,
			bool disabledTrachking = true);
		Task<IReadOnlyList<T>?> GetAsync(
			Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			List<Expression<Func<T, object>>>? includes = null,
			bool disabledTrachking = true);
		Task<T?> GetByIdAsync(object key);
		Task<T?> GetByIdAsync(params object[] keys);
		Task<IReadOnlyList<T>?> GetFromSqlAsync(FormattableString sql);
		Task<IReadOnlyList<T>?> GetFromSqlInterpolatedAsync(FormattableString sql);
		Task<IReadOnlyList<T>?> GetFromSqlRawAsync(string sql);
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
		Task<bool> AnyAsync(Expression<Func<T, bool>> conditionExpression);
	}
}

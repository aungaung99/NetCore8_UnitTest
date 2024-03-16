using Microsoft.EntityFrameworkCore;

using NetCore8_UnitTest.APIs.Data;
using NetCore8_UnitTest.APIs.Interfaces.Base;

using System.Linq.Expressions;

namespace NetCore8_UnitTest.APIs.Services.Base
{
	public abstract class RepositoryBase<T>(NetCoreDemoDbContext context) : IRepositoryBase<T> where T : class
	{
		protected NetCoreDemoDbContext Context { get; set; } = context;

		public IReadOnlyList<T> Get()
		{
			return Context.Set<T>().ToList();
		}

		public async Task<IReadOnlyList<T>?> GetAsync()
		{
			return await Context.Set<T>().ToListAsync();
		}

		public async Task<IReadOnlyList<T>?> GetAsync(Expression<Func<T, bool>> predicate)
		{
			return await Context.Set<T>().Where(predicate).ToListAsync();
		}

		public async Task<IReadOnlyList<T>?> GetAsync(Expression<Func<T, bool>>? predicate = null,
													Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
													string? includeString = null,
													bool disabledTrachking = true)
		{
			IQueryable<T> query = Context.Set<T>();
			if (disabledTrachking)
			{
				query = query.AsNoTracking();
			}

			if (!string.IsNullOrWhiteSpace(includeString))
			{
				query = query.Include(includeString);
			}

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			return orderBy != null ? await orderBy(query).ToListAsync() : (IReadOnlyList<T>)await query.ToListAsync();
		}

		public async Task<IReadOnlyList<T>?> GetAsync(Expression<Func<T, bool>>? predicate = null,
											Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
											List<Expression<Func<T, object>>>? includes = null,
											bool disabledTrachking = true)
		{
			IQueryable<T> query = Context.Set<T>();
			if (disabledTrachking)
			{
				query = query.AsNoTracking();
			}

			if (includes != null)
			{
				query = includes.Aggregate(query, (current, include) => current.Include(include));
			}

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			return orderBy != null ? await orderBy(query).ToListAsync() : (IReadOnlyList<T>)await query.ToListAsync();
		}

		public virtual async Task<T?> GetByIdAsync(object key)
		{
			return await Context.Set<T>().FindAsync(key);
		}

		public virtual async Task<T?> GetByIdAsync(params object[] keys)
		{
			return await Context.Set<T>().FindAsync(keys);
		}

		public async Task<IReadOnlyList<T>?> GetFromSqlAsync(FormattableString sql)
		{
			return await Context.Set<T>().FromSql(sql).ToListAsync();
		}

		public async Task<IReadOnlyList<T>?> GetFromSqlInterpolatedAsync(FormattableString sql)
		{
			return await Context.Set<T>().FromSqlInterpolated(sql).ToListAsync();
		}

		public async Task<IReadOnlyList<T>?> GetFromSqlRawAsync(string sql)
		{
			return await Context.Set<T>().FromSqlRaw(sql).ToListAsync();
		}

		public void Create(T entity)
		{
			_ = Context.Set<T>().Add(entity);
		}

		public void Delete(T entity)
		{
			_ = Context.Set<T>().Remove(entity);
		}

		public IQueryable<T> FindAll => Context.Set<T>().AsNoTracking();

		public IQueryable<T> FindByConditions(Expression<Func<T, bool>> conditionExpression)
		{
			return Context.Set<T>().Where(conditionExpression).AsNoTracking();
		}

		public void Update(T entity)
		{
			Context.Entry(entity).State = EntityState.Modified;
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> conditionExpression)
		{
			return await Context.Set<T>().AnyAsync(conditionExpression);
		}
	}
}

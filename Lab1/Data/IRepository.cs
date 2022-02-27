using System.Linq.Expressions;
using Lab1.Entities.Hamburgers;

namespace Lab1.Data;

public interface IRepository<TEntity> where TEntity: BaseEntity
{
    Task Create(TEntity item, CancellationToken ct);
    Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken ct);
    Task<TEntity?> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken ct);
    IQueryable<TEntity> QueryableSelect();
    Task Remove(TEntity item, CancellationToken ct);
    Task Update(TEntity item, CancellationToken ct);
}
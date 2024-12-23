using System.Linq.Expressions;

namespace Domain.Repositories;

public interface IRepository<TEntity>
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> FindFirst(Expression<Func<TEntity, bool>> predicate);
    Task<int> Save(CancellationToken cancellationToken);
}
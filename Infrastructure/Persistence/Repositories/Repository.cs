using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using NLog.Fluent;

namespace Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected DbContext Db;
    protected DbSet<TEntity> DbSet;

    public Repository(DbContext dbContext)
    {
        Db = dbContext;
        DbSet = Db.Set<TEntity>();
    }
    
    public void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity> FindFirst(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        try
        {
            var result = await Db.SaveChangesAsync(cancellationToken);
            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Log.Error(ex.Message);
            return 0;
        }
        catch (DbUpdateException ex)
        {
            Log.Error(ex.Message);
            return 0;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return 0;
        }
    }
}
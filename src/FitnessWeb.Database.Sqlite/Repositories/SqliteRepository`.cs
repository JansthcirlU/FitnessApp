using Core.Entities.Base;
using Core.Repositories;

namespace FitnessWeb.Database.Sqlite.Repositories;

public abstract class SqliteRepository<TEntity> :
    IRepository<TEntity, Guid>
    where TEntity : BaseEntity<Guid>
{
    private FitnessSqliteContext _context;

    public SqliteRepository()
    {
        // Options are known already so this is fine?
        _context = new();
    }
    public SqliteRepository(FitnessSqliteContext context)
    {
        _context = context;
    }

    public virtual Task<IQueryable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> result = _context
            .Set<TEntity>()
            .AsQueryable();
        return Task.FromResult(result);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(entity, cancellationToken);
        // await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _context.AddRangeAsync(entities, cancellationToken);
        // await _context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.FindAsync<TEntity>(id);

    public Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Remove(entity);
        // await _context.SaveChangesAsync(cancellationToken);
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<TEntity>> RemoveManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _context.RemoveRange(entities);
        // await _context.SaveChangesAsync(cancellationToken);
        return Task.FromResult(entities);
    }

    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Update(entity);
        return Task.FromResult(entity);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);
}
using Core.Entities.Base;

namespace Core.Repositories;

public interface IRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task<TEntity> FindAsync(TId id, CancellationToken cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> RemoveManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
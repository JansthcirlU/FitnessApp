using Core.Entities.Base;

namespace Core.Repositories;

public interface IRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    /// <summary>
    /// Attempts to find the entity with the given id.
    /// Returns null if there are no matching entities.
    /// </summary>
    Task<TEntity?> FindAsync(TId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds and entity to the database and saves changes.
    /// </summary>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds multiple entities to the database and saves changes.
    /// </summary>
    Task<IEnumerable<TEntity>> AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes an entity from the database and saves changes.
    /// </summary>
    Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes multiple entities from the database and saves changes.
    /// </summary>
    Task<IEnumerable<TEntity>> RemoveManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves any modifications to the database.
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
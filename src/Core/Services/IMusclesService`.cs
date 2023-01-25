using Core.Entities.Muscle;

namespace Core.Services;

public interface IMuscleService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task<Muscle> FindMuscle(Guid muscleId, CancellationToken cancellationToken = default);
    Task<IQueryable<Muscle>> GetMusclesAsync(CancellationToken cancellationToken = default);
}
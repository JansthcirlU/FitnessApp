using Core.Entities.Muscle;
using Core.Repositories;

namespace Core.Services;

public class MusclesService : IMuscleService<Guid>
{
    private IRepository<Muscle, Guid> _muscleRepository;

    public MusclesService(IRepository<Muscle, Guid> muscleRepository)
    {
        _muscleRepository = muscleRepository;
    }

    public async Task<Muscle> FindMuscle(Guid muscleId, CancellationToken cancellationToken = default)
        => await _muscleRepository.FindAsync(muscleId)
        ?? throw new ArgumentException($"Could not find muscle. There are no muscles with id {muscleId}.", nameof(muscleId));

    public async Task<IQueryable<Muscle>> GetMusclesAsync(CancellationToken cancellationToken = default)
        => await _muscleRepository.GetAllAsync(cancellationToken);
}
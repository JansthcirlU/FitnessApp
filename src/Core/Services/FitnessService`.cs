using Core.Entities.Exercises;

namespace Core.Services;

public class FitnessService<TId> : IFitnessService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    public Task AddPlanStepAsync(TId planId, ExerciseRoutine routine, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task CreateEmptyPlanAsync(string name, string description, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task CreatePlanWithRoutinesAsync(string name, string description, List<ExerciseRoutine> routines, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemovePlanStepAsync(TId planId, int step, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
using Core.Entities.Exercises;

namespace Core.Services;

public interface IFitnessService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task CreateEmptyPlanAsync(string name, string description, CancellationToken cancellationToken = default);
    Task CreatePlanWithRoutinesAsync(string name, string description, List<ExerciseRoutine> routines, CancellationToken cancellationToken = default);
    Task AddPlanStepAsync(TId planId, ExerciseRoutine routine, CancellationToken cancellationToken = default);
    Task RemovePlanStepAsync(TId planId, int step, CancellationToken cancellationToken = default);
}
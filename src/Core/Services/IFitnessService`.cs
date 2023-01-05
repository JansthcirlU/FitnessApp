using Core.Entities.Exercises;

namespace Core.Services;

public interface IFitnessService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task<WorkoutPlan> CreateEmptyPlanAsync(string name, string description, CancellationToken cancellationToken = default);
    Task<WorkoutPlan> CreatePlanWithRoutinesAsync(string name, string description, List<ExerciseRoutine> routines, CancellationToken cancellationToken = default);
    Task AddPlanStepAsync(TId planId, ExerciseRoutine routine, CancellationToken cancellationToken = default);
    Task RemovePlanStepAsync(TId planId, int step, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the plan row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditPlanAsync(TId planId, string? name, string? description, CancellationToken cancellationToken = default);
}
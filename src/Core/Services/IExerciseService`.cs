using Core.Entities.Equipment.Base;
using Core.Entities.Exercises;
using Core.Entities.Muscle;

namespace Core.Services;

public interface IExerciseService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task<IQueryable<Exercise>> GetDefaultExercisesAsync();
    Task<Exercise> FindExercise(TId exerciseId, CancellationToken cancellationToken = default);
    Task<Exercise> DefineExerciseAsync(string name, string description, List<Muscle> trainedMuscles, List<Equipment> requiredEquipment, CancellationToken cancellationToken = default);
    Task<Exercise> DefineExerciseAsync(string name, string description, MuscleGroup trainedMuscleGroup, List<Equipment> requiredEquipment, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates property values for the exercise row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditExerciseAsync(TId exerciseId, string? name, string? description, List<Muscle>? trainedMuscles, List<Equipment>? requiredEquipment, CancellationToken cancellationToken = default);
}
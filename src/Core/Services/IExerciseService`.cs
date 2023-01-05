using Core.Entities.Equipment.Base;
using Core.Entities.Muscle;

namespace Core.Services;

public interface IExerciseService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task DefineExerciseAsync(string name, string description, List<Muscle> trainedMuscles, List<Equipment> requiredEquipment, CancellationToken cancellationToken = default);
    Task DefineExerciseAsync(string name, string description, MuscleGroup trainedMuscleGroup, List<Equipment> requiredEquipment, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates property values for the exercise row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditExerciseAsync(TId exerciseId, string? newName, string? newDescription, List<Muscle>? newTrainedMuscles, List<Equipment>? newRequiredEquipment, CancellationToken cancellationToken = default);
}
using Core.Entities.Equipment.Base;
using Core.Entities.Muscle;

namespace Core.Services;

public class ExerciseService<TId> : IExerciseService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    public Task DefineExerciseAsync(string name, string description, List<Muscle> trainedMuscles, List<Equipment> requiredEquipment, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DefineExerciseAsync(string name, string description, MuscleGroup trainedMuscleGroup, List<Equipment> requiredEquipment, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task EditExerciseAsync(TId exerciseId, string? newName, string? newDescription, List<Muscle>? newTrainedMuscles, List<Equipment>? newRequiredEquipment, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
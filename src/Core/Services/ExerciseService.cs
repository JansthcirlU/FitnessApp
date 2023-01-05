using Core.Entities.Equipment.Base;
using Core.Entities.Exercises;
using Core.Entities.Muscle;
using Core.Repositories;

namespace Core.Services;

public class ExerciseService : IExerciseService<Guid>
{
    private IRepository<Exercise, Guid> _exerciseRepository;

    public ExerciseService(IRepository<Exercise, Guid> exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }
    public async Task DefineExerciseAsync(string name, string description, List<Muscle> trainedMuscles, List<Equipment> requiredEquipment, CancellationToken cancellationToken = default)
    {
        Exercise exercise = new(name, description);
        exercise.AddTrainedMuscles(trainedMuscles);
        exercise.AddRequiredEquipment(requiredEquipment);

        await _exerciseRepository.AddAsync(exercise);
    }

    public async Task DefineExerciseAsync(string name, string description, MuscleGroup trainedMuscleGroup, List<Equipment> requiredEquipment, CancellationToken cancellationToken = default)
    {
        Exercise exercise = new(name, description);
        exercise.AddGroupMuscles(trainedMuscleGroup);
        exercise.AddRequiredEquipment(requiredEquipment);

        await _exerciseRepository.AddAsync(exercise);
    }

    public async Task EditExerciseAsync(Guid exerciseId, string? name, string? description, List<Muscle>? trainedMuscles, List<Equipment>? requiredEquipment, CancellationToken cancellationToken = default)
    {
        Exercise? exercise = await _exerciseRepository.FindAsync(exerciseId, cancellationToken);
        if (exercise is null) throw new ArgumentException($"Could not edit exercise, there is on exercise with id {exerciseId}.", nameof(exerciseId));

        if (name is not null) exercise.SetName(name);
        if (description is not null) exercise.SetDescription(description);
        if (trainedMuscles is not null) exercise.EditTrainedMuscles(trainedMuscles);
        if (requiredEquipment is not null) exercise.EditRequiredEquipment(requiredEquipment);

        await _exerciseRepository.SaveChangesAsync();
    }
}
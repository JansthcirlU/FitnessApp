namespace FitnessWeb.Models;

public class ExerciseDto
{
    public ExerciseDto(string name, string description)
    {
        Name = name;
        Description = description;
        Equipment = Enumerable.Empty<EquipmentDto>();
        TrainedMuscles = Enumerable.Empty<MuscleDto>();
    }
    public ExerciseDto(
        string name,
        string description,
        IEnumerable<EquipmentDto> equipment,
        IEnumerable<MuscleDto> trainedMuscles)
    {
        Name = name;
        Description = description;
        Equipment = equipment;
        TrainedMuscles = trainedMuscles;
    }

    public string Name { get; }
    public string Description { get; }
    public IEnumerable<EquipmentDto> Equipment { get; }
    public IEnumerable<MuscleDto> TrainedMuscles { get; }
}
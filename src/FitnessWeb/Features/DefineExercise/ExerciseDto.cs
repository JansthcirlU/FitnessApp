namespace FitnessWeb.Features.DefineExercise;

public record DefinedExerciseDto(Guid ExerciseId, string Name, string Description, List<ExerciseMuscleDto> Muscles, List<EquipmentDto> Equipment);
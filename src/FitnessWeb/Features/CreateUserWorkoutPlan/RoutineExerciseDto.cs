namespace FitnessWeb.Features.CreateUserWorkoutPlan;

public record RoutineExerciseDto(Guid Id, string Name, string Description, List<RoutineExerciseMuscleDto> TrainedMuscles);
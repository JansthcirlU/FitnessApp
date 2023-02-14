namespace FitnessWeb.Features.CreateUserWorkoutPlan;

public record StepExerciseRoutineDto(RoutineExerciseDto Exercise, int Sets, int Reps, TimeSpan RestTime);
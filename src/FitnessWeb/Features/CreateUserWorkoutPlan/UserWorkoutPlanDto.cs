namespace FitnessWeb.Features.CreateUserWorkoutPlan;

public record UserWorkoutPlanDto(Guid UserId, string Name, string Description, List<UserWorkoutPlanStepDto> Steps);
using Core.Entities.Exercises;
using Core.Repositories;

namespace Core.Services;

public class FitnessService : IFitnessService<Guid>
{
    private IRepository<WorkoutPlan, Guid> _workoutPlanRepository;
    private IRepository<ExerciseRoutine, Guid> _exerciseRoutineRepository;

    public FitnessService(
        IRepository<WorkoutPlan, Guid> workoutPlanRepository,
        IRepository<ExerciseRoutine, Guid> exerciseRoutineRepository)
    {
        _workoutPlanRepository = workoutPlanRepository;
        _exerciseRoutineRepository = exerciseRoutineRepository;
    }

    public async Task AddPlanStepAsync(Guid planId, ExerciseRoutine routine, CancellationToken cancellationToken = default)
    {
        WorkoutPlan? plan = await _workoutPlanRepository.FindAsync(planId, cancellationToken);

        if (plan is null) throw new ArgumentException($"Could not add step to plan, there is no plan with id {planId}.", nameof(planId));

        plan.AddStep(routine);
        await _workoutPlanRepository.SaveChangesAsync();
    }

    public async Task<WorkoutPlan> CreateEmptyPlanAsync(string name, string description, CancellationToken cancellationToken = default)
    {
        WorkoutPlan plan = new(name, description);
        await _workoutPlanRepository.AddAsync(plan, cancellationToken);
        return plan;
    }

    public async Task<WorkoutPlan> CreatePlanWithRoutinesAsync(string name, string description, List<ExerciseRoutine> routines, CancellationToken cancellationToken = default)
    {
        WorkoutPlan plan = new(name, description);
        foreach (var routine in routines)
        {
            plan.AddStep(routine);
        }
        await _workoutPlanRepository.AddAsync(plan);
        return plan;
    }

    public async Task EditPlanAsync(Guid planId, string? name, string? description, CancellationToken cancellationToken = default)
    {
        WorkoutPlan? plan = await _workoutPlanRepository.FindAsync(planId, cancellationToken);
        if (plan is null) throw new ArgumentException($"Could not edit plan, there is no plan with id {planId}.", nameof(planId));

        if (name is not null) plan.SetName(name);
        if (description is not null) plan.SetDescription(description);
        await _workoutPlanRepository.SaveChangesAsync();
    }

    public async Task RemovePlanStepAsync(Guid planId, int step, CancellationToken cancellationToken = default)
    {
        WorkoutPlan? plan = await _workoutPlanRepository.FindAsync(planId, cancellationToken);
        if (plan is null) throw new ArgumentException($"Could not remove step from plan, there is no plan with id {planId}.", nameof(planId));

        plan.RemoveStep(step);
        await _workoutPlanRepository.SaveChangesAsync();
    }
}
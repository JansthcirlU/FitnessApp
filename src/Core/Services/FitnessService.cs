using Core.Entities.Exercises;
using Core.Entities.Users;
using Core.Repositories;
using System.Linq;

namespace Core.Services;

public class FitnessService : IFitnessService<Guid>
{
    private IRepository<WorkoutPlan, Guid> _workoutPlanRepository;
    private IRepository<ExerciseRoutine, Guid> _exerciseRoutineRepository;
    private IRepository<User, Guid> _userRepository;

    public FitnessService(
        IRepository<WorkoutPlan, Guid> workoutPlanRepository,
        IRepository<ExerciseRoutine, Guid> exerciseRoutineRepository,
        IRepository<User, Guid> userRepository)
    {
        _workoutPlanRepository = workoutPlanRepository;
        _exerciseRoutineRepository = exerciseRoutineRepository;
        _userRepository = userRepository;
    }

    public async Task<IQueryable<WorkoutPlan>> GetUserPlans(Guid userId, CancellationToken cancellationToken = default)
    {
        IQueryable<WorkoutPlan> plans = await _workoutPlanRepository.GetAllAsync();
        return plans
            .Where(p => p.User.Id == userId);
    }

    public async Task<WorkoutPlan> FindPlanAsync(Guid planId, CancellationToken cancellationToken = default)
    {
        WorkoutPlan? plan = await _workoutPlanRepository.FindAsync(planId, cancellationToken);
        if (plan is null) throw new ArgumentException($"There exists no plan with id {planId}.", nameof(planId));
        return plan;
    }

    public async Task AddPlanStepAsync(Guid planId, ExerciseRoutine routine, CancellationToken cancellationToken = default)
    {
        WorkoutPlan? plan = await _workoutPlanRepository.FindAsync(planId, cancellationToken);

        if (plan is null) throw new ArgumentException($"Could not add step to plan, there is no plan with id {planId}.", nameof(planId));

        plan.AddStep(routine);
        await _workoutPlanRepository.SaveChangesAsync();
    }

    public async Task<WorkoutPlan> CreateEmptyPlanAsync(Guid userId, string name, string description, CancellationToken cancellationToken = default)
    {
        User? user = await _userRepository.FindAsync(userId, cancellationToken);
        if (user is null) throw new ArgumentException($"Cannot add plan for user. Invalid user id {userId}.", nameof(userId));
        WorkoutPlan plan = new(name, description);
        user.AddPlan(plan);
        await _userRepository.SaveChangesAsync();
        return plan;
    }

    public async Task<WorkoutPlan> CreatePlanWithRoutinesAsync(Guid userId, string name, string description, List<ExerciseRoutine> routines, CancellationToken cancellationToken = default)
    {
        User? user = await _userRepository.FindAsync(userId, cancellationToken);
        if (user is null) throw new ArgumentException($"Cannot add plan for user. Invalid user id {userId}.", nameof(userId));
        WorkoutPlan plan = new(name, description);
        foreach (var routine in routines)
        {
            plan.AddStep(routine);
        }
        user.AddPlan(plan);
        await _userRepository.SaveChangesAsync();
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
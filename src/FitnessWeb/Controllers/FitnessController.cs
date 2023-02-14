using System.Runtime.CompilerServices;
using Core.Entities.Exercises;
using Core.Entities.Muscle;
using Core.Entities.Users;
using Core.Services;
using FitnessWeb.Features.CreateUserWorkoutPlan;
using FitnessWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FitnessController : ControllerBase
{
    private readonly IFitnessService<Guid> _fitnessService;
    private readonly IUserService<Guid> _userService;
    public FitnessController(
        IFitnessService<Guid> fitnessService,
        IUserService<Guid> userService)
    {
        _fitnessService = fitnessService;
        _userService = userService;
    }

    [HttpGet("user/{id}/plans")]
    public async IAsyncEnumerable<WorkoutPlanDto> GetUserPlans(Guid userId, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var plans = await _fitnessService
            .GetUserPlans(userId, cancellationToken);
        
        var planDtos = plans
            .Select(p => new WorkoutPlanDto(
                userId,
                p.Name,
                p.Description)); // Use some kind of mapper maybe?
        
        await foreach (var planDto in planDtos.AsAsyncEnumerable())
        {
            yield return planDto;
        }
    }
    
    [HttpPost("/plans/create")]
    public async Task<ActionResult<WorkoutPlanDto>> CreatePlan(UserWorkoutPlanDto planDto, CancellationToken cancellationToken = default)
    {
        try
        {
            WorkoutPlan plan = new(planDto.Name, planDto.Description);
            foreach (var stepDto in planDto.Steps)
            {
                Exercise exercise = new(stepDto.Routine.Exercise.Id, stepDto.Routine.Exercise.Name, stepDto.Routine.Exercise.Description);
                foreach (var muscleDto in stepDto.Routine.Exercise.TrainedMuscles)
                {
                    Muscle muscle = new(muscleDto.MuscleId, muscleDto.Name);
                    exercise.AddTrainedMuscle(muscle);
                }
                ExerciseRoutine routine = new(
                    exercise,
                    stepDto.Routine.Sets,
                    stepDto.Routine.Reps,
                    stepDto.Routine.RestTime);
                plan.AddStep(routine);
            }
            await _userService.AddUserPlanAsync(planDto.UserId, plan, cancellationToken);
            return await Task.Run(() => CreatedAtAction(nameof(CreatePlan), planDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    // [HttpPost("plans/create/test")]
    // public async Task<ActionResult<TestDto>> CreateTestPlan(TestDto test)
    // {
    //     _ = 0;
    //     await Task.Delay(500);
    //     return CreatedAtAction(nameof(CreateTestPlan), test);
    // }


    // [HttpPost("plans/create/empty/")]
    // public async Task<ActionResult<WorkoutPlan>> CreateEmptyPlanAsync(string name, string description, CancellationToken cancellationToken = default)
    // {   
    //     try
    //     {
    //         WorkoutPlan plan = await _fitnessService.CreateEmptyPlanAsync(name, description, cancellationToken);
    //         return CreatedAtAction(nameof(CreateEmptyPlanAsync), plan);
    //     }
    //     catch (System.Exception)
    //     {
    //         return BadRequest();
    //     }
    // }

    // [HttpPost("plans/create/new/")]
    // public async Task<ActionResult<WorkoutPlan>> CreateNewPlan(string name, string description, List<ExerciseRoutine> routines, CancellationToken cancellationToken = default)
    // {
    //     try
    //     {
    //         WorkoutPlan plan = await _fitnessService.CreatePlanWithRoutinesAsync(name, description, routines, cancellationToken);
    //         return CreatedAtAction(nameof(CreateNewPlan), plan);
    //     }
    //     catch (System.Exception)
    //     {
    //         return BadRequest();
    //     }
    // }
}

public class TestDto
{
    public string Name { get; set; } = null!;
    public int Age { get; set; }
}
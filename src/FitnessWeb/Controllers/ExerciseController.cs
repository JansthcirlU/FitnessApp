using System.Runtime.CompilerServices;
using Core.Entities.Equipment.Base;
using Core.Entities.Exercises;
using Core.Entities.Muscle;
using Core.Services;
using FitnessWeb.Features.DefineExercise;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IMuscleService<Guid> _muscleService;
    private readonly IExerciseService<Guid> _exerciseService;
    private readonly IEquipmentService<Guid> _equipmentService;

    public ExerciseController(
        IExerciseService<Guid> exerciseService,
        IMuscleService<Guid> muscleService, 
        IEquipmentService<Guid> equipmentService)
    {
        _exerciseService = exerciseService;
        _muscleService = muscleService;
        _equipmentService = equipmentService;
    }

    // public async IAsyncEnumerable<DefinedExerciseDto> GetUserExercises(Guid userId, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    // {
    //     throw new NotImplementedException();
    // }

    [HttpGet("/exercises")]
    public async IAsyncEnumerable<DefinedExerciseDto> GetExercises()
    {
        var exercises = await _exerciseService
            .GetDefaultExercisesAsync();
        
        var exerciseDtos = exercises
            .Include(e => e.TrainedMuscles)
            .Select(e => new DefinedExerciseDto(
                e.Id,
                e.Name,
                e.Description,
                e.TrainedMuscles
                    .Select(m => new ExerciseMuscleDto(
                        m.Id,
                        m.Name)).ToList(),
                e.RequiredEquipment
                    .Select(e => new EquipmentDto(
                        e.Id,
                        e.Name)).ToList()));
            
        await foreach (var exerciseDto in exerciseDtos.AsAsyncEnumerable())
        {
            yield return exerciseDto;
        }
    }

    [HttpGet("/muscles")]
    public async IAsyncEnumerable<ExerciseMuscleDto> GetMuscles()
    {
        var muscles = await _muscleService
            .GetMusclesAsync();
        
        var muscleDtos = muscles
            .Select(m => new ExerciseMuscleDto(m.Id, m.Name));
        
        await foreach (var muscleDto in muscleDtos.AsAsyncEnumerable())
        {
            yield return muscleDto;
        }
    }

    [HttpPost("/create")]
    public async Task<ActionResult<DefinedExerciseDto>> DefineExercise(DefinedExerciseDto exerciseDto, CancellationToken cancellationToken = default)
    {
        List<Muscle> muscles = new();
        foreach (var muscleDto in exerciseDto.Muscles)
        {
            Muscle muscle = await _muscleService.FindMuscle(muscleDto.MuscleId); // Assume muscle is already in db
            muscles.Add(muscle);
        }
        List<Equipment> equipments = new();
        foreach (var equipmentDto in exerciseDto.Equipment)
        {
            Equipment equipment = await _equipmentService.FindEquipmentAsync(equipmentDto.EquipmentId); // Assume equipment is already in db
            equipments.Add(equipment);
        }
        Exercise exercise =  await _exerciseService.DefineExerciseAsync(
            exerciseDto.Name,
            exerciseDto.Description,
            muscles,
            equipments,
            cancellationToken);
        return CreatedAtAction(nameof(DefineExercise), exercise);
    }
}
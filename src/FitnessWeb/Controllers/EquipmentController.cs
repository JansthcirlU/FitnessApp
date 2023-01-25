using System.Runtime.CompilerServices;
using Core.Entities.Equipment;
using Core.Entities.Equipment.Base;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly IEquipmentService<Guid> _equipmentService;

    public EquipmentController(
        IEquipmentService<Guid> equipmentService)
    {
        _equipmentService = equipmentService;
    }

    [HttpGet("user/{id}")]
    public async IAsyncEnumerable<Equipment> GetUserEquipment(Guid userId, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var equipment = await _equipmentService.GetUserEquipment(userId, cancellationToken);
        await foreach (var e in equipment.AsAsyncEnumerable())
        {
            yield return e;
        }
    }

    [HttpPost("accessories/create")]
    public async Task<Accessory> DefineAccessoryAsync(string name, string description, CancellationToken cancellationToken = default)
        => await _equipmentService.DefineAccessoryAsync(name, description, cancellationToken);

    [HttpPut("accessories/edit/{id}")]
    public async Task EditAccessoryAsync(Guid id, string? name, string? description, CancellationToken cancellationToken = default)
        => await _equipmentService.EditAccessoryAsync(id, name, description, cancellationToken);

    [HttpPost("bars/create")]
    public async Task<Bar> DefineWeightBarAsync(string name, double diameterMm, double lengthCm, string? description = null, CancellationToken cancellationToken = default)
        => await _equipmentService.DefineWeightBarAsync(name, diameterMm, lengthCm, description, cancellationToken);

    [HttpPut("bars/edit/{id}")]
    public async Task EditWeightBarAsync(Guid id, string? name, double? diameterMm, double? lengthCm, string? description = null, CancellationToken cancellationToken = default)
        => await _equipmentService.EditWeightBarAsync(id, name, diameterMm, lengthCm, description, cancellationToken);

    [HttpPost("machines/create")]
    public async Task<ExerciseMachine> DefineMachineAsync(string name, string description, CancellationToken cancellationToken = default)
        => await _equipmentService.DefineMachineAsync(name, description, cancellationToken);

    [HttpPut("machines/edit/{id}")]
    public async Task EditMachineAsync(Guid id, string? name, string? description, CancellationToken cancellationToken = default)
        => await _equipmentService.EditMachineAsync(id, name, description, cancellationToken);

    [HttpPost("freeweights/create")]
    public async Task<FreeWeight> DefineFreeWeightAsync(string name, double massKg, string? description = null, CancellationToken cancellationToken = default)
        => await _equipmentService.DefineFreeWeightAsync(name, massKg, description, cancellationToken);

    [HttpPut("freeweights/edit/{id}")]
    public async Task EditFreeWeightAsync(Guid id, string? name, double? massKg, string? description = null, CancellationToken cancellationToken = default)
        => await _equipmentService.EditFreeWeightAsync(id, name, massKg, description, cancellationToken);

    [HttpPost("weigtdiscs/create")]
    public async Task<WeightDisc> DefineWeightDiscAsync(string name, double massKg, double diameterMm, string? description = null, CancellationToken cancellationToken = default)
        => await _equipmentService.DefineWeightDiscAsync(name, massKg, diameterMm, description, cancellationToken);

    [HttpPut("weightdiscs/edit/{id}")]
    public async Task EditWeightDiscAsync(Guid id, string? name, double? massKg, double? diameterMm, string? description = null, CancellationToken cancellationToken = default)
        => await _equipmentService.EditWeightDiscAsync(id, name, massKg, diameterMm, description, cancellationToken);

    [HttpDelete("delete/{id}")]
    public async Task<Equipment> RemoveEquipmentAsync(Guid id, CancellationToken cancellationToken = default)
        => await _equipmentService.RemoveEquipmentAsync(id, cancellationToken);
}
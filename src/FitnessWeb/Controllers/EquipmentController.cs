using Core.Entities.Equipment;
using Core.Entities.Equipment.Base;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly IEquipmentService<Guid> _equipmentService;

    public EquipmentController(
        IEquipmentService<Guid> equipmentService)
    {
        _equipmentService = equipmentService;
    }

    [HttpGet("accessories/{id}")]
    public async Task<Accessory> GetAccessoryAsync(Guid id, CancellationToken cancellationToken = default)
        => await _equipmentService.FindAccessoryAsync(id, cancellationToken);
    
    [HttpGet("freeweights/{id}")]
    public async Task<FreeWeight> GetFreeWeightAsync(Guid id, CancellationToken cancellationToken = default)
        => await _equipmentService.FindFreeWeightAsync(id, cancellationToken);
}
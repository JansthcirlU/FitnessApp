using Core.Entities.Equipment;
using Core.Entities.Equipment.Base;
using Core.Repositories;

namespace Core.Services;

public class EquipmentService : IEquipmentService<Guid>
{
    private IRepository<Equipment, Guid> _equipmentRepository;

    public EquipmentService(IRepository<Equipment, Guid> equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public async Task DefineAccessoryAsync(string name, string description, CancellationToken cancellationToken = default)
    {
        Accessory accessory = new(name, description);
        await _equipmentRepository.AddAsync(accessory);
    }

    public async Task DefineFreeWeightAsync(string name, double massKg, string? description = null, CancellationToken cancellationToken = default)
    {
        FreeWeight freeWeight = new(name, massKg);
        if (description is not null) freeWeight.SetDescription(description);
        await _equipmentRepository.AddAsync(freeWeight);
    }

    public async Task DefineMachineAsync(string name, string description, CancellationToken cancellationToken = default)
    {
        ExerciseMachine machine = new(name, description);
        await _equipmentRepository.AddAsync(machine);
    }

    public async Task DefineWeightBarAsync(string name, double diameterMm, double lengthCm, string? description = null, CancellationToken cancellationToken = default)
    {
        Bar bar = new(name, diameterMm, lengthCm);
        if (description is not null) bar.SetDescription(description);
        await _equipmentRepository.AddAsync(bar);
    }

    public async Task DefineWeightDiscAsync(string name, double massKg, double diameterMm, string? description = null, CancellationToken cancellationToken = default)
    {
        WeightDisc disc = new(name, massKg, diameterMm);
        if (description is not null) disc.SetDescription(description);
        await _equipmentRepository.AddAsync(disc);
    }

    public async Task EditAccessoryAsync(Guid id, string? name, string? description, CancellationToken cancellationToken = default)
    {
        Equipment? equipment = await _equipmentRepository.FindAsync(id, cancellationToken);
        if (equipment is null) throw new ArgumentException($"Could not edit accessory, there is no accessory with id {id}.", nameof(id));
        if (equipment is not Accessory accessory) throw new InvalidOperationException($"Equipment with the given id {id} is not an accessory.");

        if (name is not null) accessory.SetName(name);
        if (description is not null) accessory.SetDescription(description);
        await _equipmentRepository.SaveChangesAsync();
    }

    public async Task EditFreeWeightAsync(Guid id, string? name, double? massKg, string? description = null, CancellationToken cancellationToken = default)
    {
        Equipment? equipment = await _equipmentRepository.FindAsync(id, cancellationToken);
        if (equipment is null) throw new ArgumentException($"Could not edit free weight, there is no free weight with id {id}.", nameof(id));
        if (equipment is not FreeWeight freeWeight) throw new InvalidOperationException($"Equipment with the given id {id} is not a free weight.");

        if (name is not null) freeWeight.SetName(name);
        if (massKg is double m) freeWeight.SetMass(m);
        if (description is not null) freeWeight.SetDescription(description);
        await _equipmentRepository.SaveChangesAsync();
    }

    public async Task EditMachineAsync(Guid id, string? name, string? description, CancellationToken cancellationToken = default)
    {
        Equipment? equipment = await _equipmentRepository.FindAsync(id, cancellationToken);
        if (equipment is null) throw new ArgumentException($"Could not edit exercise machine, there is no exercise machine with id {id}.", nameof(id));
        if (equipment is not ExerciseMachine machine) throw new InvalidOperationException($"Equipment with the given id {id} is not an exercise machine.");

        if (name is not null) machine.SetName(name);
        if (description is not null) machine.SetDescription(description);
        await _equipmentRepository.SaveChangesAsync();
    }

    public async Task EditWeightBarAsync(Guid id, string? name, double? diameterMm, double? lengthCm, string? description = null, CancellationToken cancellationToken = default)
    {
        Equipment? equipment = await _equipmentRepository.FindAsync(id, cancellationToken);
        if (equipment is null) throw new ArgumentException($"Could not edit bar, there is no bar with id {id}.", nameof(id));
        if (equipment is not Bar bar) throw new InvalidOperationException($"Equipment with the given id {id} is not a bar.");

        if (name is not null) bar.SetName(name);
        if (diameterMm is double d) bar.SetDiameter(d);
        if (lengthCm is double l) bar.SetLength(l);
        if (description is not null) bar.SetDescription(description);
        await _equipmentRepository.SaveChangesAsync();
    }

    public async Task EditWeightDiscAsync(Guid id, string? name, double? massKg, double? diameterMm, string? description = null, CancellationToken cancellationToken = default)
    {
        Equipment? equipment = await _equipmentRepository.FindAsync(id, cancellationToken);
        if (equipment is null) throw new ArgumentException($"Could not edit weight disc, there is no weight disc with id {id}.", nameof(id));
        if (equipment is not WeightDisc disc) throw new InvalidOperationException($"Equipment with the given id {id} is not a weight disc.");

        if (name is not null) disc.SetName(name);
        if (massKg is double m) disc.SetMass(m);
        if (diameterMm is double d) disc.SetDiameter(d);
        if (description is not null) disc.SetDescription(description);
        await _equipmentRepository.SaveChangesAsync();
    }

    public async Task RemoveEquipmentAsync(Guid id)
    {
        Equipment? equipment = await _equipmentRepository.FindAsync(id);
        if (equipment is null) throw new ArgumentException($"Could not remove equipment, there is no equipment with id {id}", nameof(id));

        await _equipmentRepository.RemoveAsync(equipment);
    }
}
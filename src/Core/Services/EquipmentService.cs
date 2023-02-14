using Core.Entities.Equipment;
using Core.Entities.Equipment.Base;
using Core.Repositories;

namespace Core.Services;

internal class EquipmentService : IEquipmentService<Guid>
{
    private IRepository<Equipment, Guid> _equipmentRepository;

    public EquipmentService(IRepository<Equipment, Guid> equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public async Task<Equipment> FindEquipmentAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Equipment? equipment = await _equipmentRepository.FindAsync(id, cancellationToken);
        if (equipment is not Equipment eq) throw new ArgumentException($"There is no equipment with id {id}.", nameof(id));
        return eq;
    }

    public async Task<IQueryable<Equipment>> GetUserEquipment(Guid userId, CancellationToken cancellationToken = default)
    {
        var equipment = await _equipmentRepository.GetAllAsync();
        return equipment
            .Where(e => e.Owners.Any(o => o.Id == userId)); // How to uninclude other users from the returned entity?
    }

    public async Task<Accessory> DefineAccessoryAsync(string name, string description, CancellationToken cancellationToken = default)
    {
        Accessory accessory = new(name, description);
        await _equipmentRepository.AddAsync(accessory);
        return accessory;
    }

    public async Task<FreeWeight> DefineFreeWeightAsync(string name, double massKg, string? description = null, CancellationToken cancellationToken = default)
    {
        FreeWeight freeWeight = new(name, massKg);
        if (description is not null) freeWeight.SetDescription(description);
        await _equipmentRepository.AddAsync(freeWeight);
        return freeWeight;
    }

    public async Task<ExerciseMachine> DefineMachineAsync(string name, string description, CancellationToken cancellationToken = default)
    {
        ExerciseMachine machine = new(name, description);
        await _equipmentRepository.AddAsync(machine);
        return machine;
    }

    public async Task<Bar> DefineWeightBarAsync(string name, double diameterMm, double lengthCm, string? description = null, CancellationToken cancellationToken = default)
    {
        Bar bar = new(name, diameterMm, lengthCm);
        if (description is not null) bar.SetDescription(description);
        await _equipmentRepository.AddAsync(bar);
        return bar;
    }

    public async Task<WeightDisc> DefineWeightDiscAsync(string name, double massKg, double diameterMm, string? description = null, CancellationToken cancellationToken = default)
    {
        WeightDisc disc = new(name, massKg, diameterMm);
        if (description is not null) disc.SetDescription(description);
        await _equipmentRepository.AddAsync(disc);
        return disc;
    }

    public async Task EditAccessoryAsync(Guid id, string? name, string? description, CancellationToken cancellationToken = default)
    {
        Accessory accessory = await FindAccessoryAsync(id, cancellationToken);
        if (name is not null) accessory.SetName(name);
        if (description is not null) accessory.SetDescription(description);
        await _equipmentRepository.UpdateAsync(accessory);
    }

    public async Task EditFreeWeightAsync(Guid id, string? name, double? massKg, string? description = null, CancellationToken cancellationToken = default)
    {
        FreeWeight freeWeight = await FindFreeWeightAsync(id, cancellationToken);
        if (name is not null) freeWeight.SetName(name);
        if (massKg is double m) freeWeight.SetMass(m);
        if (description is not null) freeWeight.SetDescription(description);
        await _equipmentRepository.UpdateAsync(freeWeight);
    }

    public async Task EditMachineAsync(Guid id, string? name, string? description, CancellationToken cancellationToken = default)
    {
        ExerciseMachine machine = await FindMachineAsync(id, cancellationToken);
        if (name is not null) machine.SetName(name);
        if (description is not null) machine.SetDescription(description);
        await _equipmentRepository.UpdateAsync(machine);
    }

    public async Task EditWeightBarAsync(Guid id, string? name, double? diameterMm, double? lengthCm, string? description = null, CancellationToken cancellationToken = default)
    {
        Bar bar = await FindWeightBarAsync(id, cancellationToken);
        if (name is not null) bar.SetName(name);
        if (diameterMm is double d) bar.SetDiameter(d);
        if (lengthCm is double l) bar.SetLength(l);
        if (description is not null) bar.SetDescription(description);
        await _equipmentRepository.UpdateAsync(bar);
    }

    public async Task EditWeightDiscAsync(Guid id, string? name, double? massKg, double? diameterMm, string? description = null, CancellationToken cancellationToken = default)
    {
        WeightDisc disc = await FindWeightDiscAsync(id, cancellationToken);
        if (name is not null) disc.SetName(name);
        if (massKg is double m) disc.SetMass(m);
        if (diameterMm is double d) disc.SetDiameter(d);
        if (description is not null) disc.SetDescription(description);
        await _equipmentRepository.UpdateAsync(disc);
    }

    public async Task<Accessory> FindAccessoryAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Equipment equipment = await FindEquipmentAsync(id, cancellationToken);
        if (equipment is not Accessory accessory) throw new InvalidOperationException($"Equipment with id {id} is not an accessory.");
        return accessory;
    }

    public async Task<FreeWeight> FindFreeWeightAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Equipment equipment = await FindEquipmentAsync(id, cancellationToken);
        if (equipment is not FreeWeight freeWeight) throw new InvalidOperationException($"Equipment with id {id} is not a free weight.");
        return freeWeight;
    }

    public async Task<ExerciseMachine> FindMachineAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Equipment equipment = await FindEquipmentAsync(id, cancellationToken);
        if (equipment is not ExerciseMachine machine) throw new InvalidOperationException($"Equipment with id {id} is not an exercise machine.");
        return machine;
    }

    public async Task<Bar> FindWeightBarAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Equipment equipment = await FindEquipmentAsync(id, cancellationToken);
        if (equipment is not Bar bar) throw new InvalidOperationException($"Equipment with id {id} is not a bar.");
        return bar;
    }

    public async Task<WeightDisc> FindWeightDiscAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Equipment equipment = await FindEquipmentAsync(id, cancellationToken);
        if (equipment is not WeightDisc disc) throw new InvalidOperationException($"Equipment with id {id} is not a weight disc.");
        return disc;
    }

    public async Task<Equipment> RemoveEquipmentAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Equipment? equipment = await _equipmentRepository.FindAsync(id, cancellationToken);
        if (equipment is null) throw new ArgumentException($"Could not remove equipment, there is no equipment with id {id}", nameof(id));

        await _equipmentRepository.RemoveAsync(equipment, cancellationToken);
        return equipment;
    }
}
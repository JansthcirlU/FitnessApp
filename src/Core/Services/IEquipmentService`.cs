using Core.Entities.Equipment;
using Core.Entities.Equipment.Base;

namespace Core.Services;

public interface IEquipmentService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task<Accessory> FindAccessoryAsync(TId id, CancellationToken cancellationToken = default);
    Task<Accessory> DefineAccessoryAsync(string name, string description, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the Accessory row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditAccessoryAsync(TId id, string? name, string? description, CancellationToken cancellationToken = default);
    
    Task<Bar> FindWeightBarAsync(TId id, CancellationToken cancellationToken = default);
    Task<Bar> DefineWeightBarAsync(string name, double diameterMm, double lengthCm, string? description = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the WeightBar row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditWeightBarAsync(TId id, string? name, double? diameterMm, double? lengthCm, string? description = null, CancellationToken cancellationToken = default);
    
    Task<ExerciseMachine> FindMachineAsync(TId id, CancellationToken cancellationToken = default);
    Task<ExerciseMachine> DefineMachineAsync(string name, string description, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the Machine row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditMachineAsync(TId id, string? name, string? description, CancellationToken cancellationToken = default);
    
    Task<FreeWeight> FindFreeWeightAsync(TId id, CancellationToken cancellationToken = default);
    Task<FreeWeight> DefineFreeWeightAsync(string name, double massKg, string? description = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the FreeWeight row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditFreeWeightAsync(TId id, string? name, double? massKg, string? description = null, CancellationToken cancellationToken = default);
    
    Task<WeightDisc> FindWeightDiscAsync(TId id, CancellationToken cancellationToken = default);
    Task<WeightDisc> DefineWeightDiscAsync(string name, double massKg, double diameterMm, string? description = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the WeightDisc row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditWeightDiscAsync(TId id, string? name, double? massKg, double? diameterMm, string? description = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a piece of equipment from the database and saves changes.
    /// </summary>
    Task<Equipment> RemoveEquipmentAsync(TId id, CancellationToken cancellationToken = default);
}
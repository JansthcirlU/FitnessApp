namespace Core.Services;

public interface IEquipmentService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task DefineAccessoryAsync(string name, string description, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the Accessory row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditAccessoryAsync(TId id, string? name, string? description, CancellationToken cancellationToken = default);
    
    Task DefineWeightBarAsync(string name, double diameterMm, double lengthCm, string? description = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the WeightBar row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditWeightBarAsync(TId id, string? name, double? diameterMm, double? lengthCm, string? description = null, CancellationToken cancellationToken = default);
    
    Task DefineMachineAsync(string name, string description, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the Machine row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditMachineAsync(TId id, string? name, string? description, CancellationToken cancellationToken = default);
    
    Task DefineFreeWeightAsync(string name, double massKg, string? description = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the FreeWeight row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditFreeWeightAsync(TId id, string? name, double? massKg, string? description = null, CancellationToken cancellationToken = default);
    
    Task DefineWeightDiscAsync(string name, double massKg, double diameterMm, string? description = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates property values for the WeightDisc row with the given id
    /// for non-null new values.
    /// </summary>
    Task EditWeightDiscAsync(TId id, string? name, double? massKg, double? diameterMm, string? description = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a piece of equipment from the database and saves changes.
    /// </summary>
    Task RemoveEquipmentAsync(TId id);
}
namespace Core.Services;

public interface IEquipmentService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task DefineAccessoryAsync(string name, string description, CancellationToken cancellationToken = default);
    Task DefineWeightBarAsync(string name, double diameterMm, double lengthCm, string? description = null, CancellationToken cancellationToken = default);
    Task DefineMachineAsync(string name, string description, CancellationToken cancellationToken = default);
    Task DefineFreeWeightAsync(string name, double massKg, string? description = null, CancellationToken cancellationToken = default);
    Task DefineWeightDiscAsync(string name, double massKg, double diameterMm, string? description = null, CancellationToken cancellationToken = default);
}
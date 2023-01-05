namespace Core.Services;

public class EquipmentService<TId> : IEquipmentService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    public Task DefineAccessoryAsync(string name, string description, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DefineFreeWeightAsync(string name, double massKg, string? description = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DefineMachineAsync(string name, string description, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DefineWeightBarAsync(string name, double diameterMm, double lengthCm, string? description = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DefineWeightDiscAsync(string name, double massKg, double diameterMm, string? description = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
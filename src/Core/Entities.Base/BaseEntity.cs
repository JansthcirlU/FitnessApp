namespace Core.Entities.Base;

/// <summary>
/// Base entity with custom type for Id.
/// </summary>
public abstract class BaseEntity<T>
    where T : struct, IComparable<T>, IEquatable<T>
{
    public T Id { get; set; }
}
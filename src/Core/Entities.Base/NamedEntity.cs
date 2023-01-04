namespace Core.Entities.Base;

/// <summary>
/// Base entity with a name property.
/// </summary>
public abstract class NamedEntity<T> : BaseEntity<T>
    where T : struct, IComparable<T>, IEquatable<T>
{
    protected NamedEntity()
    {
        
    }
    public NamedEntity(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = null!;
}
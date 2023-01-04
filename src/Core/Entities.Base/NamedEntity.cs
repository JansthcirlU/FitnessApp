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
        SetName(name);
    }

    public string Name { get; private set; } = null!;

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name must not be null or empty.", nameof(name));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must not be null or whitespace.", nameof(name));
        
        Name = name;
    }
}
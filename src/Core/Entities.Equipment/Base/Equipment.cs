using Core.Entities.Base;
using Core.Entities.Users;

namespace Core.Entities.Equipment.Base;

/// <summary>
/// Base equipment class which contains the necessary
/// entity relationships for all subclasses.
/// </summary>
public abstract class Equipment : NamedEntity<Guid>
{
    private HashSet<Exercises.Exercise> _suitableExercises = null!;
    private HashSet<User> _owners = null!;

    protected Equipment()
    {
        
    }
    public Equipment(string name) : base(name)
    {
        _suitableExercises = new();
        _owners = new();
    }
    public Equipment(string name, string description)
        : this(name)
    {
        SetDescription(description);
    }

    public EquipmentType Type { get; protected set; }
    public string? Description { get; private set; }
    public IEnumerable<User> Owners => _owners.ToList();
    public IEnumerable<Exercises.Exercise> SuitableExercises => _suitableExercises.ToList();

    public void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description must not be empty", nameof(description));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description must not be whitespace.", nameof(description));

        Description = description;
    }

    public void RemoveDescription()
        => Description = null;
}
using Core.Entities.Base;

namespace Core.Entities.Muscle;

/// <summary>
/// Customised grouping of muscles.
/// </summary>
public class MuscleGroup : NamedEntity<Guid>
{
    private HashSet<Muscle> _muscles = null!;

    private MuscleGroup()
    {
        
    }
    public MuscleGroup(string name) : base(name)
    {
        _muscles = new();
    }

    public IEnumerable<Muscle> Muscles => _muscles.ToList();

    public void AddMuscle(Muscle muscle)
    {
        if (!_muscles.Add(muscle)) throw new InvalidOperationException($"Muscle \"{muscle.Name}\" already exists in this group.");
    }

    public void RemoveMuscle(Muscle muscle)
    {
        if (!_muscles.Remove(muscle)) throw new InvalidOperationException($"Muscle \"{muscle.Name}\" is not a member of this group.");
    }

    public void Clear()
        => _muscles.Clear();
}
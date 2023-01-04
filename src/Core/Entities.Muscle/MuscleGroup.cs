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
}
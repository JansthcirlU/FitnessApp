using Core.Entities.Base;

namespace Core.Entities.Exercises;

/// <summary>
/// An exercise that trains one or more muscles
/// using some or no equipment.
/// </summary>
public class Exercise : NamedEntity<Guid>
{
    private HashSet<Muscle.Muscle> _trainedMuscles = null!;
    private HashSet<Equipment.Base.Equipment> _requiredEquipment = null!;

    private Exercise()
    {
        
    }
    public Exercise(string name, string description)
        : base(name)
    {
        Description = description;
        _trainedMuscles = new();
        _requiredEquipment = new();
    }

    public string Description { get; private set; } = null!;
    public IEnumerable<Muscle.Muscle> TrainedMuscles => _trainedMuscles.ToList();
    public IEnumerable<Equipment.Base.Equipment> RequiredEquipment => _requiredEquipment.ToList();
}
using Core.Entities.Base;
using eqBase = Core.Entities.Equipment.Base;

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
        SetDescription(description);
        _trainedMuscles = new();
        _requiredEquipment = new();
    }

    public string Description { get; private set; } = null!;
    public IEnumerable<Muscle.Muscle> TrainedMuscles => _trainedMuscles.ToList();
    public IEnumerable<Equipment.Base.Equipment> RequiredEquipment => _requiredEquipment.ToList();

    public void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description must not be null or empty.", nameof(description));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description must not be null or whitespace.", nameof(description));

        Description = description;
    }

    public void AddRequiredEquipment(eqBase.Equipment equipment)
    {
        if (!_requiredEquipment.Add(equipment)) throw new InvalidOperationException($"Equipment \"{equipment.Name}\" is already required for this exercise.");
    }

    public void RemoveRequiredEquipment(eqBase.Equipment equipment)
    {
        if (!_requiredEquipment.Remove(equipment)) throw new InvalidOperationException($"Equipment \"{equipment.Name}\" is not required for this exercise.");
    }

    public void AddTrainedMuscle(Muscle.Muscle muscle)
    {
        if (!_trainedMuscles.Add(muscle)) throw new InvalidOperationException($"Muscle \"{muscle.Name}\" is already trained by this exercises.");
    }

    public void RemoveTrainedMuscle(Muscle.Muscle muscle)
    {
        if (!_trainedMuscles.Remove(muscle)) throw new InvalidOperationException($"Muscle \"{muscle.Name}\" is not trained by this exercise.");
    }

    public void AddGroupMuscles(Muscle.MuscleGroup muscleGroup)
    {
        foreach (var muscle in muscleGroup.Muscles)
        {
            try
            {
                AddTrainedMuscle(muscle);
            }
            catch (System.InvalidOperationException)
            {
                continue;
            }
        }
    }

    public void RemoveGroupMuscles(Muscle.MuscleGroup muscleGroup)
    {
        foreach (var muscle in muscleGroup.Muscles)
        {
            try
            {
                RemoveTrainedMuscle(muscle);
            }
            catch (System.InvalidOperationException)
            {
                continue;
            }
        }
    }
}
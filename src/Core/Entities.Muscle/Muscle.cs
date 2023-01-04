using Core.Entities.Base;

namespace Core.Entities.Muscle;

/// <summary>
/// Muscles that are trained by doing exercises.
/// </summary>
public class Muscle : NamedEntity<Guid>
{
    private HashSet<Exercises.Exercise> _muscleExercises = null!;
    private HashSet<MuscleGroup> _muscleGroups = null!;

    private Muscle()
    {
    }
    public Muscle(string name) : base(name)
    {
        _muscleExercises = new();
        _muscleGroups = new();
    }

    public IEnumerable<Exercises.Exercise> MuscleExercises => _muscleExercises.ToList();
    public IEnumerable<MuscleGroup> MuscleGroups => _muscleGroups.ToList();
}
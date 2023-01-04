using Core.Entities.Base;

namespace Core.Entities.Exercises;

public class ExerciseRoutine : BaseEntity<Guid>
{
    private HashSet<WorkoutPlanStep> _routineSteps = null!;

    private ExerciseRoutine()
    {
        
    }
    public ExerciseRoutine(Exercise exercise, int sets, int reps, TimeSpan restTime)
    {        
        Exercise = exercise;
        Sets = sets;
        Repetitions = reps;
        RestTime = restTime;
        _routineSteps = new();
    }

    public Exercise Exercise { get; private set; } = null!;
    public int Sets { get; private set; }
    public int Repetitions { get; private set; }
    public TimeSpan RestTime { get; private set; }
    public IEnumerable<WorkoutPlanStep> RoutineSteps => _routineSteps.ToList();

    public void ChangeExercise(Exercise exercise)
    {
        Exercise = exercise;
    }

    public void UpdateSets(int sets)
    {
        if (sets < 1) throw new ArgumentOutOfRangeException(nameof(sets), "Routine must involve at least one set of repetitions.");
        Sets = sets;
    }

    public void UpdateRepetitions(int reps)
    {
        if (reps < 1) throw new ArgumentOutOfRangeException(nameof(reps), "Routine must involve at least one repetition per set.");
        Repetitions = reps;
    }

    public void UpdateRestTime(TimeSpan restTime)
    {
        if (restTime <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(restTime), "Rest period between two sets muts be greater than 0 seconds.");
        RestTime = restTime;
    }
}
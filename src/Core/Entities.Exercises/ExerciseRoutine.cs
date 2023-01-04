namespace Core.Entities.Exercises;

public record ExerciseRoutine
{
    private ExerciseRoutine()
    {
        
    }
    public ExerciseRoutine(Exercise exercise, int sets, int reps, TimeSpan restTime)
    {
        if (sets < 1) throw new ArgumentOutOfRangeException(nameof(sets), "Routine must involve at least one set of repetitions.");
        if (reps < 1) throw new ArgumentOutOfRangeException(nameof(reps), "Routine must involve at least one repetition per set.");
        if (restTime <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(restTime), "Rest period between two sets muts be greater than 0 seconds.");
        
        Exercise = exercise;
        Sets = sets;
        Repetitions = reps;
        RestTime = restTime;
    }

    public Exercise Exercise { get; private set; } = null!;
    public int Sets { get; private set; }
    public int Repetitions { get; private set; }
    public TimeSpan RestTime { get; private set; }
}
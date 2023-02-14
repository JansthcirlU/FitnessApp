namespace FitnessWeb.Models;

public class ExerciseRoutineDto
{
    public ExerciseRoutineDto(ExerciseDto exercise, int sets, int reps, TimeSpan restTime)
    {
        Exercise = exercise;
        Sets = sets;
        Reps = reps;
        RestTime = restTime;
    }

    public ExerciseDto Exercise { get; }
    public int Sets { get; }
    public int Reps { get; }
    public TimeSpan RestTime { get; }
}
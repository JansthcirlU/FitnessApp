namespace FitnessWeb.Models;

public class WorkoutPlanStepDto
{
    public WorkoutPlanStepDto(int step, ExerciseRoutineDto routine)
    {
        Step = step;
        Routine = routine;
    }

    public int Step { get; }
    public ExerciseRoutineDto Routine { get; }
}
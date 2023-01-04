using Core.Entities.Base;

namespace Core.Entities.Exercises;

public class WorkoutPlanStep : BaseEntity<Guid>
{
    private WorkoutPlanStep()
    {
        
    }
    public WorkoutPlanStep(int step, ExerciseRoutine stepExercise)
    {
        Step = step;
        StepExercise = stepExercise;
    }

    public int Step { get; private set; }
    public ExerciseRoutine StepExercise { get; private set; } = null!;

    public void UpdateStepNumber(int step)
    {
        if (Step == step) return;
        if (step < 1) throw new ArgumentOutOfRangeException(nameof(step), "Step number must be at least 1.");

        Step = step;
    }
}
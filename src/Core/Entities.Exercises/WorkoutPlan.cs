using Core.Entities.Base;
using Core.Entities.Users;

namespace Core.Entities.Exercises;

public class WorkoutPlan : NamedEntity<Guid>
{
    private HashSet<WorkoutPlanStep> _steps = null!;

    private WorkoutPlan()
    {
        
    }
    public WorkoutPlan(/* User user,  */string name, string description)
        : base(name)
    {
        // User = user; // Does EF/ORM deal with this?
        SetDescription(description);
        _steps = new();
    }

    public string Description { get; private set; } = null!;
    public User User { get; private set; } = null!;
    public IEnumerable<WorkoutPlanStep> Steps => _steps.ToList();

    public void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description must not be null or empty.", nameof(description));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description must not be null or whitespace.", nameof(description));

        Description = description;
    }

    public void AddStep(ExerciseRoutine exerciseRoutine)
    {
        int lastStepNumber = Steps.Max(s => s.Step);
        WorkoutPlanStep step = new(lastStepNumber + 1, exerciseRoutine);
        _steps.Add(step);
    }

    public void RemoveStep(int stepNumber)
    {
        WorkoutPlanStep? step = _steps.SingleOrDefault(s => s.Step == stepNumber);
        if (step is not WorkoutPlanStep stepToRemove) throw new ArgumentOutOfRangeException(nameof(stepNumber), $"Could not find step with step number {stepNumber}.");

        _steps.Remove(stepToRemove);
        IEnumerable<WorkoutPlanStep> stepsAfter = _steps.Where(s => s.Step > stepNumber);
        foreach (var nextStep in stepsAfter)
        {
            nextStep.UpdateStepNumber(nextStep.Step - 1);
        }
    }

    public void EditStepNumber(int stepNumber, int newStepNumber)
    {
        WorkoutPlanStep? step = _steps.SingleOrDefault(s => s.Step == stepNumber);
        if (step is not WorkoutPlanStep stepToEdit) throw new ArgumentOutOfRangeException(nameof(stepNumber), $"Could not find step with step number {stepNumber}.");
        if (_steps.Any(s => s.Step == newStepNumber)) throw new ArgumentException($"There already exists a step with step number {newStepNumber}.", nameof(newStepNumber));

        stepToEdit.UpdateStepNumber(newStepNumber);
    }
}
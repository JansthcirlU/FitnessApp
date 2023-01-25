using Core.Entities.Exercises;

namespace FitnessWeb.Models;

public class WorkoutPlanDto
{
    public WorkoutPlanDto(Guid userId, string name, string description)
    {
        UserId = userId;
        Name = name;
        Description = description;
    }
    // public WorkoutPlanDto(Guid userId, string name, string description, List<int> ints) :
    //     this(userId, name, description)
    // {
        
    // }

    public Guid UserId { get; }
    public string Name { get; }
    public string Description { get; }
}
using Core.Entities.Base;
using Core.Entities.Exercises;

namespace Core.Entities.Users;

public class User : BaseEntity<Guid>
{
    private HashSet<WorkoutPlan> _plans = null!;
    private HashSet<Equipment.Base.Equipment> _equipment = null!;

    private User()
    {
        
    }
    public User(string firstName, string lastName, DateTime dateOfBirth)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetDateOfBirth(dateOfBirth);
        _equipment = new();
        _plans = new();
    }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public DateTime DateOfBirth { get; private set; }
    public IEnumerable<WorkoutPlan> Plans => _plans.ToList();
    public IEnumerable<Equipment.Base.Equipment> Equipment => _equipment.ToList();

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrEmpty(firstName)) throw new ArgumentException("Name must not be null or empty.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("Name must not be null or whitespace.", nameof(firstName));

        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (string.IsNullOrEmpty(lastName)) throw new ArgumentException("Name must not be null or empty.", nameof(lastName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Name must not be null or whitespace.", nameof(lastName));

        LastName = lastName;
    }

    public void SetDateOfBirth(DateTime dateOfBirth)
    {
        if (dateOfBirth > DateTime.Now) throw new ArgumentException("Date of birth must be in the past.", nameof(dateOfBirth));

        DateOfBirth = dateOfBirth;
    }

    public void AddPlan(WorkoutPlan plan)
    {
        if (!_plans.Add(plan)) throw new ArgumentException($"Could not add plan, user already has this workout plan.", nameof(plan));
    }

    public void RemovePlan(WorkoutPlan plan)
    {
        if (!_plans.Remove(plan)) throw new ArgumentException($"Could not remove plan, user does not have this workout plan.", nameof(plan));
    }

    public void AddEquipment(Equipment.Base.Equipment equipment)
    {
        if (!_equipment.Add(equipment)) throw new ArgumentException($"Could not add equipment, user already owns this equipment.", nameof(equipment));
    }

    public void RemoveEquipment(Equipment.Base.Equipment equipment)
    {
        if (!_equipment.Remove(equipment)) throw new ArgumentException($"Could not remove equipment, user does not own this equipment.", nameof(equipment));
    }
}
using eqBase = Core.Entities.Equipment.Base;

namespace Core.Entities.Equipment;

public class ExerciseMachine : eqBase.Equipment
{
    private ExerciseMachine()
    {
        
    }
    public ExerciseMachine(string name, string description)
        : base(name, description)
    {
        
    }
}
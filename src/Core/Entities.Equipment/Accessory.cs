using eqBase = Core.Entities.Equipment.Base;

namespace Core.Entities.Equipment;

public class Accessory : eqBase.Equipment
{
    public Accessory()
    {
        
    }
    public Accessory(string name, string description)
        : base(name, description)
    {

    }
}
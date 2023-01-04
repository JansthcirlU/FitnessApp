using eqBase = Core.Entities.Equipment.Base;

namespace Core.Entities.Equipment;

/// <summary>
/// A heavy object that can be used for
/// weight lifting without other types
/// of equipment.
/// </summary>
public class FreeWeight : eqBase.Equipment
{
    public FreeWeight(string name, double massKg) : base(name)
    {
        MassKg = massKg;
    }

    public double MassKg { get; private set; }
}
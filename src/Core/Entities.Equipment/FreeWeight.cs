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
        SetMass(massKg);
    }

    public double MassKg { get; private set; }

    public void SetMass(double massKg)
    {
        if (double.IsNaN(massKg)) throw new ArgumentException("Mass must be a valid number.", nameof(massKg));
        if (double.IsInfinity(massKg)) throw new ArgumentException("Mass must be a finite number.", nameof(massKg));
        if (massKg <= 0) throw new ArgumentException("Mass must be greater than zero.", nameof(massKg));

        MassKg = massKg;
    }
}
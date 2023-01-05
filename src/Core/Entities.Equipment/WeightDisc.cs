using eqBase = Core.Entities.Equipment.Base;

namespace Core.Entities.Equipment;

/// <summary>
/// Weighted disc with a circular hole in the middle
/// so that it can be loaded onto a bar for lifting.
/// </summary>
public class WeightDisc : eqBase.Equipment
{
    private WeightDisc()
    {
        
    }
    public WeightDisc(string name, double massKg, double diameterMm)
        : base(name)
    {
        SetMass(massKg);
        SetDiameter(diameterMm);
    }

    public double MassKg { get; private set; }
    public double DiameterMm { get; private set; }

    public void SetMass(double massKg)
    {
        if (double.IsNaN(massKg)) throw new ArgumentException("Mass must be a valid number.", nameof(massKg));
        if (double.IsInfinity(massKg)) throw new ArgumentException("Mass must be a finite number.", nameof(massKg));
        if (massKg <= 0) throw new ArgumentException("Mass must be greater than zero.", nameof(massKg));

        MassKg = massKg;
    }

    public void SetDiameter(double diameterMm)
    {
        if (double.IsNaN(diameterMm)) throw new ArgumentException("Diameter must be a valid number.", nameof(diameterMm));
        if (double.IsInfinity(diameterMm)) throw new ArgumentException("Diameter must be a finite number.", nameof(diameterMm));
        if (diameterMm <= 0) throw new ArgumentException("Diameter must be greater than zero.", nameof(diameterMm));

        DiameterMm = diameterMm;
    }
}
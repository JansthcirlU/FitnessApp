using eqBase = Core.Entities.Equipment.Base;

namespace Core.Entities.Equipment;

/// <summary>
/// A metal rod that holds weight discs
/// of the same diameter.
/// </summary>
public class Bar : eqBase.Equipment
{
    public Bar()
    {
        
    }
    public Bar(string name, double diameterMm, double lengthCm)
        : base(name)
    {
        SetDiameter(diameterMm);
        SetLength(lengthCm);
    }

    public double DiameterMm { get; private set; }
    public double LengthCm { get; private set; }

    public void SetDiameter(double diameterMm)
    {
        if (double.IsNaN(diameterMm)) throw new ArgumentException("Diameter must be a valid number.", nameof(diameterMm));
        if (double.IsInfinity(diameterMm)) throw new ArgumentException("Diameter must be a finite number.", nameof(diameterMm));
        if (diameterMm <= 0) throw new ArgumentException("Diameter must be greater than zero.", nameof(diameterMm));

        DiameterMm = diameterMm;
    }

    public void SetLength(double lengthCm)
    {
        if (double.IsNaN(lengthCm)) throw new ArgumentException("Length must be a valid number.", nameof(lengthCm));
        if (double.IsInfinity(lengthCm)) throw new ArgumentException("Length must be a finite number.", nameof(lengthCm));
        if (lengthCm <= 0) throw new ArgumentException("Length must be greater than zero.", nameof(lengthCm));

        LengthCm = lengthCm;
    }
}
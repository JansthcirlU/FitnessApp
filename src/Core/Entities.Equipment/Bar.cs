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
        DiameterMm = diameterMm;
        LengthCm = lengthCm;
    }

    public double DiameterMm { get; private set; }
    public double LengthCm { get; private set; }
}
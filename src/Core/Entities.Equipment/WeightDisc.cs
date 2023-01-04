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
        MassKg = massKg;
        DiameterMm = diameterMm;
    }

    public double MassKg { get; private set; }
    public double DiameterMm { get; private set; }
}
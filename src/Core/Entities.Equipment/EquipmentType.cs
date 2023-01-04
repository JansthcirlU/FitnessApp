namespace Core.Entities.Equipment;

/// <summary>
/// Discriminator enum for EF Core
/// </summary>
public enum EquipmentType
{
    None,
    FreeWeight,
    Disc,
    Bar,
    Machine,
    Accessory
}
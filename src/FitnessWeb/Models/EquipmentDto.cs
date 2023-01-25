namespace FitnessWeb.Models;

public class EquipmentDto
{
    public EquipmentDto(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string Description { get; }
}
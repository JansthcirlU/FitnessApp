namespace FitnessWeb.Models;

public class MuscleDto
{
    public MuscleDto(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
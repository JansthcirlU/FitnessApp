using Core.Entities.Exercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWeb.Database.EntityTypeConfigurations;

public class ExerciseTypeConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder
            .HasMany(ex => ex.RequiredEquipment)
            .WithMany(eq => eq.SuitableExercises);
        builder
            .HasMany(ex => ex.TrainedMuscles)
            .WithMany(m => m.MuscleExercises);
    }
}
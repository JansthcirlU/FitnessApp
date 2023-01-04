using System.Diagnostics;
using Core.Entities.Exercises;
using FitnessWeb.Database.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Database;

public abstract class FitnessDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Debugger.Launch();
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .ApplyConfiguration(new EquipmentTypeConfiguration())
            .ApplyConfiguration(new ExerciseTypeConfiguration());
    }
}

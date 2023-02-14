using Core.Entities.Equipment;
using Core.Entities.Equipment.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWeb.Database.EntityTypeConfigurations;

public class EquipmentTypeConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder
            .HasDiscriminator(e => e.Type)
            .HasValue<FreeWeight>(EquipmentType.FreeWeight)
            .HasValue<WeightDisc>(EquipmentType.Disc)
            .HasValue<Bar>(EquipmentType.Bar)
            .HasValue<ExerciseMachine>(EquipmentType.Machine)
            .HasValue<Accessory>(EquipmentType.Accessory);
    }
}
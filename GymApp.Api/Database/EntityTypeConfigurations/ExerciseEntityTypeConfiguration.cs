using GymApp.Shared.Models.Exercises.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.Api.Database.EntityTypeConfigurations;

public class ExerciseEntityTypeConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(x => x.ExerciseId);

        builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.MuscleGroups)
            .IsRequired();

        builder.Property(x => x.Equipment)
            .IsRequired();

        builder.HasMany(e => e.WorkoutSets)
            .WithOne(ws => ws.Exercise);

        builder.Navigation(e => e.WorkoutSets)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

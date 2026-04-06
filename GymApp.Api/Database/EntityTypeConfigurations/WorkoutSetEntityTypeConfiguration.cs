using GymApp.Shared.Models.ExerciseSets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.Api.Database.EntityTypeConfigurations;

public class WorkoutSetEntityTypeConfiguration : IEntityTypeConfiguration<WorkoutSet>
{
    public void Configure(EntityTypeBuilder<WorkoutSet> builder)
    {
        builder.HasKey(x => x.WorkoutSetId);

        builder.Property(x => x.SessionId)
            .IsRequired();

        builder.Property(x => x.ExerciseId)
            .IsRequired();

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.Property(x => x.Reps);

        builder.Property(x => x.Duration);

        builder.Property(x => x.RestTime)
            .IsRequired();

        builder.Property(x => x.DoneAt)
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.HasOne(ws => ws.Session)
            .WithMany(s => s.WorkoutSets)
            .HasForeignKey(ws => ws.SessionId);

        builder.HasOne(ws => ws.Exercise)
            .WithMany(e => e.WorkoutSets)
            .HasForeignKey(ws => ws.ExerciseId);
    }
}

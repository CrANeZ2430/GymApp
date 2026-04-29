using GymApp.Shared.Models.WorkoutLogs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.Api.Database.EntityTypeConfigurations;

public class WorkoutLogEntityTypeConfiguration : IEntityTypeConfiguration<WorkoutLog>
{
    public void Configure(EntityTypeBuilder<WorkoutLog> builder)
    {
        builder.HasKey(x => x.WorkoutLogId);

        builder.Property(x => x.SessionId)
            .IsRequired();

        builder.Property(x => x.ExerciseId)
            .IsRequired();

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.Property(x => x.Sets)
            .IsRequired()
            .HasDefaultValue(3);

        builder.Property(x => x.Reps);

        builder.Property(x => x.Duration);

        builder.Property(x => x.RestTime)
            .IsRequired();

        builder.HasOne(ws => ws.Session)
            .WithMany(s => s.WorkoutLogs)
            .HasForeignKey(ws => ws.SessionId);

        builder.HasOne(ws => ws.Exercise)
            .WithMany(e => e.WorkoutLogs)
            .HasForeignKey(ws => ws.ExerciseId);
    }
}

using GymApp.Shared.Models.Sessions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.Api.Database.EntityTypeConfigurations;

public class SessionEntityTypeConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(x => x.SessionId);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.Date)
            .IsRequired();

        builder.Property(x => x.Note)
            .HasMaxLength(60)
            .IsRequired();

        builder.HasOne(s => s.AppUser)
            .WithMany(au => au.Sessions)
            .HasForeignKey(s => s.UserId);

        builder.HasMany(s => s.WorkoutSets)
            .WithOne(ws => ws.Session);

        builder.Navigation(s => s.WorkoutSets)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

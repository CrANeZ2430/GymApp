using GymApp.Shared.Models.AppUsers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.Api.Database.EntityTypeConfigurations;

public class AppUserEntityTypeConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(x => x.AppUserId);

        builder.Property(x => x.UserName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.Age)
            .IsRequired();

        builder.HasMany(au => au.Sessions)
            .WithOne(s => s.AppUser);

        builder.Navigation(au => au.Sessions)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

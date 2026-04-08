using GymApp.Shared.Models.AppUsers.Models;
using GymApp.Shared.Models.Exercises.Models;
using GymApp.Shared.Models.WorkoutSets.Models;
using GymApp.Shared.Models.Sessions.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Api.Database;

public class GymAppDbContext(DbContextOptions<GymAppDbContext> options) : DbContext(options)
{
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkoutSet> WorkoutSets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymAppDbContext).Assembly);
        modelBuilder.HasDefaultSchema("gymApp");
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }
}

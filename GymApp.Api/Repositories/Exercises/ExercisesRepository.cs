using GymApp.Api.Database;
using GymApp.Shared.Models.Exercises.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Api.Repositories.Exercises;

public class ExercisesRepository(GymAppDbContext dbContext) : IExercisesRepository
{
    public async Task<Exercise[]> GetAsync(CancellationToken ct = default)
    {
        return await dbContext.Exercises
            //.Include(e => e.WorkoutSets)
            .AsNoTracking()
            .ToArrayAsync(ct);
    }

    public async Task<Exercise?> GetByIdAsync(Guid exerciseId, CancellationToken ct = default)
    {
        return await dbContext.Exercises
            //.Include(e => e.WorkoutSets)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ExerciseId == exerciseId, ct);
    }

    public async Task CreateAsync(Exercise exercise, CancellationToken ct = default)
    {
        await dbContext.AddAsync(exercise, ct);
    }

    public void Update(Exercise exercise)
    {
        dbContext.Update(exercise);
    }

    public void Delete(Exercise exercise)
    {
        dbContext.Remove(exercise);
    }
}

using GymApp.Api.Database;
using GymApp.Shared.Models.WorkoutSets.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Api.Repositories.WorkoutSets;

public class WorkoutSetsRepository(GymAppDbContext dbContext) : IWorkoutSetsRepository
{
    public async Task<WorkoutSet[]> GetAsync(CancellationToken ct = default)
    {
        return await dbContext.WorkoutSets
            .Include(ws => ws.Exercise)
            .Include(ws => ws.Session)
                .ThenInclude(s => s.AppUser)
            .AsNoTracking()
            .ToArrayAsync(ct);
    }

    public async Task<WorkoutSet?> GetByIdAsync(Guid workoutSetId, CancellationToken ct = default)
    {
        return await dbContext.WorkoutSets
            .Include(ws => ws.Exercise)
            .Include(ws => ws.Session)
                .ThenInclude(s => s.AppUser)
            .AsNoTracking()
            .FirstOrDefaultAsync(ws => ws.WorkoutSetId == workoutSetId, ct);
    }

    public async Task CreateAsync(WorkoutSet workoutSet, CancellationToken ct = default)
    {
        await dbContext.AddAsync(workoutSet, ct);
    }

    public void Update(WorkoutSet workoutSet)
    {
        dbContext.Update(workoutSet);
    }

    public void Delete(WorkoutSet workoutSet)
    {
        dbContext.Remove(workoutSet);
    }
}

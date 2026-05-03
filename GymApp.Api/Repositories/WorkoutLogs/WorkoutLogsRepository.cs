using GymApp.Api.Database;
using GymApp.Shared.Models.WorkoutLogs.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Api.Repositories.WorkoutLogs;

public class WorkoutLogsRepository(GymAppDbContext dbContext) : IWorkoutLogsRepository
{
    public async Task<IEnumerable<WorkoutLog>> GetAsync(CancellationToken ct = default)
    {
        return await dbContext.WorkoutLogs
            .Include(ws => ws.Exercise)
            //.Include(ws => ws.Session)
                //.ThenInclude(s => s.AppUser)
            .AsNoTracking()
            .ToArrayAsync(ct);
    }

    public async Task<IEnumerable<WorkoutLog>> GetFromSessionByIdAsync(Guid sessionId, CancellationToken ct = default)
    {
        return await dbContext.WorkoutLogs
            .Where(w => w.SessionId == sessionId)
            .Include(ws => ws.Exercise)
            .ToArrayAsync(ct);
    }

    public async Task<WorkoutLog?> GetByIdAsync(Guid workoutLogId, CancellationToken ct = default)
    {
        return await dbContext.WorkoutLogs
            .Include(ws => ws.Exercise)
            //.Include(ws => ws.Session)
                //.ThenInclude(s => s.AppUser)
            .AsNoTracking()
            .FirstOrDefaultAsync(ws => ws.WorkoutLogId == workoutLogId, ct);
    }

    public async Task CreateAsync(WorkoutLog workoutLog, CancellationToken ct = default)
    {
        await dbContext.AddAsync(workoutLog, ct);
    }

    public void Update(WorkoutLog workoutLog)
    {
        dbContext.Update(workoutLog);
    }

    public void Delete(WorkoutLog workoutLog)
    {
        dbContext.Remove(workoutLog);
    }
}

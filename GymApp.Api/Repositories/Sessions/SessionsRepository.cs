using GymApp.Api.Database;
using GymApp.Shared.Models.Sessions.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Api.Repositories.Sessions;

public class SessionsRepository(GymAppDbContext dbContext) : ISessionsRepository
{
    public async Task<Session[]> GetAsync(CancellationToken ct = default)
    {
        return await dbContext.Sessions
            .Include(s => s.AppUser)
            //.Include(s => s.WorkoutSets)
            .AsNoTracking()
            .ToArrayAsync(ct);
    }

    public async Task<Session?> GetByIdAsync(Guid sessionsId, CancellationToken ct = default)
    {
        return await dbContext.Sessions
            .Include(s => s.AppUser)
            //.Include(s => s.WorkoutSets)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.SessionId == sessionsId, ct);
            
    }

    public async Task CreateAsync(Session session, CancellationToken ct = default)
    {
        await dbContext.AddAsync(session, ct);
    }

    public void Update(Session session)
    {
        dbContext.Update(session);
    }

    public void Delete(Session session)
    {
        dbContext.Remove(session);
    }
}

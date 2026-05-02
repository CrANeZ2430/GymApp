using GymApp.Api.Database;
using GymApp.Shared.Models.AppUsers.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Api.Repositories.AppUsers;

public class AppUsersRepository(GymAppDbContext dbContext) : IAppUsersRepository
{
    public async Task<IEnumerable<AppUser>> GetAsync(CancellationToken ct = default)
    {
        return await dbContext.AppUsers
            .Include(au => au.Sessions)
            .AsNoTracking()
            .ToArrayAsync(ct);
    }

    public async Task<AppUser?> GetByIdAsync(Guid appUserId, CancellationToken ct = default)
    {
        return await dbContext.AppUsers
            .Include(au => au.Sessions)
            .AsNoTracking()
            .FirstOrDefaultAsync(au => au.AppUserId == appUserId, ct);
    }

    public async Task CreateAsync(AppUser appUser, CancellationToken ct = default)
    {
        await dbContext.AddAsync(appUser, ct);
    }

    public void UpdateAsync(AppUser appUser)
    {
        dbContext.Update(appUser);
    }

    public void DeleteAsync(AppUser appUser)
    {
        dbContext.Remove(appUser);
    }
}

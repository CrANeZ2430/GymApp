using GymApp.Api.Database;
using GymApp.Shared.Models.AppUsers.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Api.Repositories.AppUsers;

public class AppUsersRepository(GymAppDbContext dbContext) : IAppUsersRepository
{
    public Task<AppUser[]> GetUsers(CancellationToken ct = default)
    {
        return dbContext.AppUsers
            .Include(au => au.Sessions)
            .AsNoTracking()
            .ToArrayAsync(ct);
    }

    public Task<AppUser> GetUserById(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
    
    public async Task Create(AppUser appUser, CancellationToken ct = default)
    {
        await dbContext.AddAsync(appUser, ct);
    }

    public void Update(AppUser appUser)
    {
        throw new NotImplementedException();
    }

    public void Delete(AppUser appUser)
    {
        throw new NotImplementedException();
    }
}

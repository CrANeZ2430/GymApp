using GymApp.Shared.Models.AppUsers.Models;

namespace GymApp.Api.Repositories.AppUsers;

public interface IAppUsersRepository
{
    Task<AppUser[]> GetUsers(CancellationToken ct = default);
    Task<AppUser> GetUserById(CancellationToken ct = default);
    Task Create(AppUser appUser, CancellationToken ct = default);
    void Update(AppUser appUser);
    void Delete(AppUser appUser);
}

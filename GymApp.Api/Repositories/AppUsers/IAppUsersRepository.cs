using GymApp.Shared.Models.AppUsers.Models;

namespace GymApp.Api.Repositories.AppUsers;

public interface IAppUsersRepository
{
    Task<AppUser[]> GetAsync(CancellationToken ct = default);
    Task<AppUser?> GetByIdAsync(Guid appUserId, CancellationToken ct = default);
    Task CreateAsync(AppUser appUser, CancellationToken ct = default);
    void UpdateAsync(AppUser appUser);
    void DeleteAsync(AppUser appUser);
}

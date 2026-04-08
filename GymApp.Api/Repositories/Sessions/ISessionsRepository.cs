using GymApp.Shared.Models.Sessions.Models;

namespace GymApp.Api.Repositories.Sessions;

public interface ISessionsRepository
{
    Task<Session[]> GetAsync(CancellationToken ct = default);
    Task<Session?> GetByIdAsync(Guid sessionsId, CancellationToken ct = default);
    Task CreateAsync(Session session, CancellationToken ct = default);
    void Update(Session session);
    void Delete(Session session);

}

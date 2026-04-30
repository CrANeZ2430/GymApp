using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Sessions.Dtos;

namespace GymApp.Visual.Services.Sessions;

public interface ISessionsService
{
    Task<SessionDto[]> GetSessionsAsync(CancellationToken ct = default);
    Task<bool> CreateSessionAsync(CreateSessionDto dto, CancellationToken ct = default);
}

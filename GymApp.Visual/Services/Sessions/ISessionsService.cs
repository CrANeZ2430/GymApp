using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Sessions.Dtos;

namespace GymApp.Visual.Services.Sessions;

public interface ISessionsService
{
    Task<IEnumerable<SessionDto>> GetAsync(CancellationToken ct = default);
    Task<bool> CreateAsync(CreateSessionDto dto, CancellationToken ct = default);
}

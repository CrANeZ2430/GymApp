using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Sessions.Dtos;
using GymApp.Visual.Constants;
using GymApp.Visual.Services.Common;
using System.Diagnostics;
using System.Net.Http.Json;

namespace GymApp.Visual.Services.Sessions;

public class SessionsService(HttpClient client) : BaseService(client), ISessionsService
{
    public async Task<bool> CreateAsync(CreateSessionDto dto, CancellationToken ct = default)
    {
        try
        {
            var response = await _client.PostAsJsonAsync(
                GymAppConstants.SESSIONS_ENDPOINT, dto, _options, ct);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return false;
        }
    }

    public async Task<IEnumerable<SessionDto>> GetAsync(CancellationToken ct = default)
    {
        try
        {
            var sessions = await _client.GetFromJsonAsync<IEnumerable<SessionDto>>(
                GymAppConstants.SESSIONS_ENDPOINT, _options, ct);
            return sessions ?? Enumerable.Empty<SessionDto>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return Enumerable.Empty<SessionDto>();
        }
    }
}

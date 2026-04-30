using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Sessions.Dtos;
using GymApp.Visual.Constants;
using System.Diagnostics;
using System.Net.Http.Json;

namespace GymApp.Visual.Services.Sessions;

public class SessionsService(HttpClient client) : BaseService(client), ISessionsService
{
    public async Task<bool> CreateSessionAsync(CreateSessionDto dto, CancellationToken ct = default)
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

    public async Task<SessionDto[]> GetSessionsAsync(CancellationToken ct = default)
    {
        try
        {
            var sessions = await _client.GetFromJsonAsync<SessionDto[]>(
                GymAppConstants.SESSIONS_ENDPOINT, _options, ct);
            return sessions ?? Array.Empty<SessionDto>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return Array.Empty<SessionDto>();
        }
    }
}

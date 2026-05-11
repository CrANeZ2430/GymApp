using GymApp.Shared.Dtos;
using GymApp.Shared.Models.WorkoutLogs.Dtos;
using GymApp.Visual.Constants;
using GymApp.Visual.Services.Common;
using System.Diagnostics;
using System.Net.Http.Json;

namespace GymApp.Visual.Services.WorkoutLogs;

public class WorkoutLogsService(HttpClient httpClient) : BaseService(httpClient), IWorkoutLogsService
{
    public async Task<bool> CreateAsync(CreateWorkoutLogDto dto, CancellationToken ct = default)
    {
        try
        {
            var response = await _client.PostAsJsonAsync(
                GymAppConstants.WORKOUTLOGS_ENDPOINT, dto, _options, ct);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return false;
        }
    }

    public async Task<IEnumerable<WorkoutLogDto>> GetFromSessionByIdAsync(Guid sessionId, CancellationToken ct = default)
    {
        try
        {
            var workoutLogs = await _client.GetFromJsonAsync<IEnumerable<WorkoutLogDto>>(
                GymAppConstants.WORKOUTLOGS_ENDPOINT + $"/session/{sessionId}", _options, ct);
            return workoutLogs ?? Enumerable.Empty<WorkoutLogDto>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return Enumerable.Empty<WorkoutLogDto>();
        }
    }
}

using GymApp.Shared.Dtos;
using GymApp.Shared.Models.WorkoutLogs.Dtos;
using GymApp.Visual.Constants;
using System.Diagnostics;
using System.Net.Http.Json;

namespace GymApp.Visual.Services.WorkoutLogs;

public class WorkoutLogsService(HttpClient httpClient) : BaseService(httpClient), IWorkoutLogsService
{
    public async Task<bool> CreateWorkoutLogAsync(CreateWorkoutLogDto dto, CancellationToken ct = default)
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

    public async Task<WorkoutLogDto[]> GetWorkoutLogForSessionAsync(Guid SessionId, CancellationToken ct = default)
    {
        try
        {
            var workoutLogs = await _client.GetFromJsonAsync<WorkoutLogDto[]>(
                GymAppConstants.WORKOUTLOGS_ENDPOINT, _options, ct);
            return workoutLogs ?? Array.Empty<WorkoutLogDto>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return Array.Empty<WorkoutLogDto>();
        }
    }
}

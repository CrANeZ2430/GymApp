using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Exercises.Dtos;
using GymApp.Shared.Models.Sessions.Dtos;
using GymApp.Visual.Constants;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GymApp.Visual.Services;

public class GymAppService(HttpClient client)
{
    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public async Task<ExerciseDto[]> GetExercisesAsync(CancellationToken ct = default)
    {
        try
        {
            var exercises = await client.GetFromJsonAsync<ExerciseDto[]>(
                GymAppConstants.EXERCISES_ENDPOINT, options, ct);
            return exercises ?? Array.Empty<ExerciseDto>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return Array.Empty<ExerciseDto>();
        }
    }

    public async Task<bool> CreateExerciseAsync(CreateExerciseDto dto, CancellationToken ct = default)
    {
        try
        {
            var response = await client.PostAsJsonAsync(
                GymAppConstants.EXERCISES_ENDPOINT, dto, options, ct);
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
            var sessions = await client.GetFromJsonAsync<SessionDto[]>(
                GymAppConstants.SESSIONS_ENDPOINT, options, ct);
            return sessions ?? Array.Empty<SessionDto>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return Array.Empty<SessionDto>();
        }
    }

    public async Task<bool> CreateSessionAsync(CreateSessionDto dto, CancellationToken ct = default)
    {
        try
        {
            var response = await client.PostAsJsonAsync(
                GymAppConstants.SESSIONS_ENDPOINT, dto, options, ct);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return false;
        }
    }
}
using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Exercises.Dtos;
using GymApp.Visual.Constants;
using System.Diagnostics;
using System.Net.Http.Json;

namespace GymApp.Visual.Services.Exercises;

public class ExercisesService(HttpClient client) : BaseService(client), IExercisesService
{
    public async Task<bool> CreateExerciseAsync(CreateExerciseDto dto, CancellationToken ct = default)
    {
        try
        {
            var response = await _client.PostAsJsonAsync(
                GymAppConstants.EXERCISES_ENDPOINT, dto, _options, ct);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return false;
        }
    }

    public async Task<ExerciseDto[]> GetExercisesAsync(CancellationToken ct = default)
    {
        try
        {
            var exercises = await _client.GetFromJsonAsync<ExerciseDto[]>(
                GymAppConstants.EXERCISES_ENDPOINT, _options, ct);
            return exercises ?? Array.Empty<ExerciseDto>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return Array.Empty<ExerciseDto>();
        }
    }
}

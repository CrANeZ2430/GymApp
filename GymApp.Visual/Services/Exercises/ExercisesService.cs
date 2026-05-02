using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Exercises.Dtos;
using GymApp.Visual.Constants;
using GymApp.Visual.Services.Common;
using System.Diagnostics;
using System.Net.Http.Json;

namespace GymApp.Visual.Services.Exercises;

public class ExercisesService(HttpClient client) : BaseService(client), IExercisesService
{
    public async Task<bool> CreateAsync(CreateExerciseDto dto, CancellationToken ct = default)
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

    public async Task<IEnumerable<ExerciseDto>> GetAsync(CancellationToken ct = default)
    {
        try
        {
            var exercises = await _client.GetFromJsonAsync<IEnumerable<ExerciseDto>>(
                GymAppConstants.EXERCISES_ENDPOINT, _options, ct);
            return exercises ?? Enumerable.Empty<ExerciseDto>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return Enumerable.Empty<ExerciseDto>();
        }
    }
}

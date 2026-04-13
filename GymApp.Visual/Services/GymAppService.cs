using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Exercises.Dtos;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GymApp.Visual.Services;

public class GymAppService(HttpClient client)
{
    public const string EXERCISES_ENDPOINT = "exercises";

    public async Task<ExerciseDto[]> GetExercisesAsync(CancellationToken ct = default)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };

            var exercises = await client.GetFromJsonAsync<ExerciseDto[]>(EXERCISES_ENDPOINT, options, ct);
            return exercises ?? Array.Empty<ExerciseDto>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return Array.Empty<ExerciseDto>();
        }
    }

    public async Task<bool> CreateExercise(CreateExerciseDto dto, CancellationToken ct = default)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };

            var response = await client.PostAsJsonAsync(EXERCISES_ENDPOINT, dto, options, ct);

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"API Error: {ex.Message}");
            return false;
        }
    }
}
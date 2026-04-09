using GymApp.Shared.Dtos;
using System.Net.Http.Json;

namespace GymApp.Visual.Services;

public class GymAppService(HttpClient client)
{
    //private const string BASE_URL = "https://10.0.2.2:7267/api/";

    public async Task<ExerciseDto[]> GetExercisesAsync(CancellationToken ct = default)
    {
        try
        {
            var appUsers = await client.GetFromJsonAsync<ExerciseDto[]>("exercise", ct);
            return appUsers ?? Array.Empty<ExerciseDto>();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"API Error: {ex.Message}");
            return Array.Empty<ExerciseDto>();
        }
    }
}
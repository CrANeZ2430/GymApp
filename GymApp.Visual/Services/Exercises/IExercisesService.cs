using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Exercises.Dtos;

namespace GymApp.Visual.Services.Exercises;

public interface IExercisesService
{
    Task<ExerciseDto[]> GetExercisesAsync(CancellationToken ct = default);
    Task<bool> CreateExerciseAsync(CreateExerciseDto dto, CancellationToken ct = default);
}

using GymApp.Shared.Dtos;
using GymApp.Shared.Models.Exercises.Dtos;

namespace GymApp.Visual.Services.Exercises;

public interface IExercisesService
{
    Task<IEnumerable<ExerciseDto>> GetAsync(CancellationToken ct = default);
    Task<bool> CreateAsync(CreateExerciseDto dto, CancellationToken ct = default);
}

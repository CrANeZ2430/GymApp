using GymApp.Shared.Models.Exercises.Models;

namespace GymApp.Api.Repositories.Exercises;

public interface IExercisesRepository
{
    Task<Exercise[]> GetAsync(CancellationToken ct = default);
    Task<Exercise?> GetByIdAsync(Guid exerciseId, CancellationToken ct = default);
    Task CreateAsync(Exercise exercise, CancellationToken ct = default);
    void Update(Exercise exercise);
    void Delete(Exercise exercise);
}

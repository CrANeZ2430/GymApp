using GymApp.Shared.Models.WorkoutSets.Models;

namespace GymApp.Api.Repositories.WorkoutSets;

public interface IWorkoutSetsRepository
{
    Task<WorkoutSet[]> GetAsync(CancellationToken ct = default);
    Task<WorkoutSet?> GetByIdAsync(Guid workoutSetId, CancellationToken ct = default);
    Task CreateAsync(WorkoutSet workoutSet, CancellationToken ct = default);
    void Update(WorkoutSet workoutSet);
    void Delete(WorkoutSet workoutSet);
}

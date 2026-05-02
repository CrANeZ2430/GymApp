using GymApp.Shared.Models.WorkoutLogs.Models;

namespace GymApp.Api.Repositories.WorkoutLogs;

public interface IWorkoutLogsRepository
{
    Task<IEnumerable<WorkoutLog>> GetAsync(CancellationToken ct = default);
    Task<IEnumerable<WorkoutLog>> GetFromSessionByIdAsync(Guid sessionId, CancellationToken ct = default);
    Task<WorkoutLog?> GetByIdAsync(Guid workoutLogId, CancellationToken ct = default);
    Task CreateAsync(WorkoutLog workoutLog, CancellationToken ct = default);
    void Update(WorkoutLog workoutLog);
    void Delete(WorkoutLog workoutLog);
}

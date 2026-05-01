using GymApp.Shared.Dtos;
using GymApp.Shared.Models.WorkoutLogs.Dtos;

namespace GymApp.Visual.Services.WorkoutLogs;

public interface IWorkoutLogsService
{
    Task<WorkoutLogDto[]> GetWorkoutLogForSessionAsync(Guid SessionId, CancellationToken ct = default);
    Task<bool> CreateWorkoutLogAsync(CreateWorkoutLogDto dto, CancellationToken ct = default);
}

using GymApp.Shared.Dtos;
using GymApp.Shared.Models.WorkoutLogs.Dtos;

namespace GymApp.Visual.Services.WorkoutLogs;

public interface IWorkoutLogsService
{
    Task<IEnumerable<WorkoutLogDto>> GetFromSessionByIdAsync(Guid sessionId, CancellationToken ct = default);
    Task<bool> CreateAsync(CreateWorkoutLogDto dto, CancellationToken ct = default);
}

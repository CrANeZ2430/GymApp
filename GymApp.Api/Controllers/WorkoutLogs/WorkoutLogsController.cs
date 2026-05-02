using GymApp.Shared.Dtos;
using GymApp.Api.Repositories.UnitOfWork;
using GymApp.Api.Repositories.WorkoutLogs;
using GymApp.Shared.Models.WorkoutLogs.Dtos;
using GymApp.Shared.Models.WorkoutLogs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers.WorkoutLogs;

[Route("api/[controller]")]
[ApiController]
public class WorkoutLogsController(
    IWorkoutLogsRepository workoutLogsRepository,
    IUnitOfWorkRepository unitOfWorkRepository)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetWorkoutLogs(
        CancellationToken ct = default)
    {
        var workoutLogs = await workoutLogsRepository.GetAsync(ct);
        var workoutLogDtos = workoutLogs.Select(wl =>
            new WorkoutLogDto(
                wl.WorkoutLogId,
                wl.ExerciseId,
                wl.SessionId,
                wl.Weight,
                wl.Sets,
                wl.Reps,
                wl.Duration,
                wl.RestTime));

        return Ok(workoutLogDtos);
    }

    [HttpGet("session/{sessionId:guid}")]
    public async Task<IActionResult> GetWorkoutLogsFromSessionById(
        [FromRoute] Guid sessionId,
        CancellationToken ct = default)
    {
        var workoutLogs = await workoutLogsRepository.GetFromSessionByIdAsync(sessionId, ct);
        var workoutLogDtos = workoutLogs.Select(wl => new WorkoutLogDto(
                wl.WorkoutLogId,
                wl.ExerciseId,
                wl.SessionId,
                wl.Weight,
                wl.Sets,
                wl.Reps,
                wl.Duration,
                wl.RestTime));

        return Ok(workoutLogDtos);
    }

    [HttpGet("{workoutLogId:guid}")]
    public async Task<IActionResult> GetWorkoutLogById(
        [FromRoute] Guid workoutLogId,
        CancellationToken ct = default)
    {
        var workoutLog = await workoutLogsRepository.GetByIdAsync(workoutLogId, ct);
        var workoutLogDto = new WorkoutLogDto(
                workoutLog.WorkoutLogId,
                workoutLog.ExerciseId,
                workoutLog.SessionId,
                workoutLog.Weight,
                workoutLog.Sets,
                workoutLog.Reps,
                workoutLog.Duration,
                workoutLog.RestTime);

        return Ok(workoutLogDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkoutLog(
        [FromBody] CreateWorkoutLogDto dto,
        CancellationToken ct = default)
    {
        var workoutLog = WorkoutLog.Create(dto);
        await workoutLogsRepository.CreateAsync(workoutLog, ct);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return CreatedAtAction(nameof(GetWorkoutLogById), new { workoutLogId = workoutLog.WorkoutLogId }, null);
    }

    [HttpPut("{workoutLogId:guid}")]
    public async Task<IActionResult> UpdateWorkoutLog(
        [FromRoute] Guid workoutLogId,
        [FromBody] UpdateWorkoutLogDto dto,
        CancellationToken ct = default)
    {
        var workoutLog = await workoutLogsRepository.GetByIdAsync(workoutLogId, ct);
        workoutLog.Update(dto);
        workoutLogsRepository.Update(workoutLog);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }

    [HttpDelete("{workoutLogId:guid}")]
    public async Task<IActionResult> DeleteWorkoutLog(
        [FromRoute] Guid workoutLogId,
        CancellationToken ct = default)
    {
        var workoutLog = await workoutLogsRepository.GetByIdAsync(workoutLogId, ct);
        workoutLogsRepository.Delete(workoutLog);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }
}

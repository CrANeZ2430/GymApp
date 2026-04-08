using GymApp.Api.Controllers.Dtos;
using GymApp.Api.Repositories.UnitOfWork;
using GymApp.Api.Repositories.WorkoutSets;
using GymApp.Shared.Models.WorkoutSets.Dtos;
using GymApp.Shared.Models.WorkoutSets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers.WorkoutSets;

[Route("api/[controller]")]
[ApiController]
public class WorkoutSetsController(
    IWorkoutSetsRepository workoutSetsRepository,
    IUnitOfWorkRepository unitOfWorkRepository)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetWorkoutSets(
        CancellationToken ct = default)
    {
        var workoutSets = await workoutSetsRepository.GetAsync(ct);
        var workoutSetsDto = workoutSets.Select(ws =>
            new WorkoutSetDto(
                ws.WorkoutSetId,
                new ExerciseDto(
                    ws.Exercise.ExerciseId,
                    ws.Exercise.Title,
                    ws.Exercise.MuscleGroups,
                    ws.Exercise.Equipment),
                new SessionDto(
                    ws.Session.SessionId,
                    new AppUserDto(
                        ws.Session.AppUser.AppUserId,
                        ws.Session.AppUser.UserName,
                        ws.Session.AppUser.Email,
                        ws.Session.AppUser.Age),
                    ws.Session.Date,
                    ws.Session.Note),
                ws.Weight,
                ws.Reps,
                ws.Duration,
                ws.RestTime,
                ws.DoneAt));

        return Ok(workoutSetsDto);
    }

    [HttpGet("{workoutSetId:guid}")]
    public async Task<IActionResult> GetWorkoutSetById(
        [FromRoute] Guid workoutSetId,
        CancellationToken ct = default)
    {
        var workoutSet = await workoutSetsRepository.GetByIdAsync(workoutSetId, ct);
        var workoutSetDto = new WorkoutSetDto(
                workoutSet.WorkoutSetId,
                new ExerciseDto(
                    workoutSet.Exercise.ExerciseId,
                    workoutSet.Exercise.Title,
                    workoutSet.Exercise.MuscleGroups,
                    workoutSet.Exercise.Equipment),
                new SessionDto(
                    workoutSet.Session.SessionId,
                    new AppUserDto(
                        workoutSet.Session.AppUser.AppUserId,
                        workoutSet.Session.AppUser.UserName,
                        workoutSet.Session.AppUser.Email,
                        workoutSet.Session.AppUser.Age),
                    workoutSet.Session.Date,
                    workoutSet.Session.Note),
                workoutSet.Weight,
                workoutSet.Reps,
                workoutSet.Duration,
                workoutSet.RestTime,
                workoutSet.DoneAt);

        return Ok(workoutSetDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkoutSet(
        [FromBody] CreateWorkoutSetDto dto,
        CancellationToken ct = default)
    {
        var workoutSet = WorkoutSet.Create(dto);
        await workoutSetsRepository.CreateAsync(workoutSet, ct);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return CreatedAtAction(nameof(GetWorkoutSetById), new { workoutSetId = workoutSet.WorkoutSetId }, null);
    }

    [HttpPut("{workoutSetId:guid}")]
    public async Task<IActionResult> UpdateWorkoutSet(
        [FromRoute] Guid workoutSetId,
        [FromBody] UpdateWorkoutSetDto dto,
        CancellationToken ct = default)
    {
        var workoutSet = await workoutSetsRepository.GetByIdAsync(workoutSetId, ct);
        workoutSet.Update(dto);
        workoutSetsRepository.Update(workoutSet);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }

    [HttpDelete("{workoutSetId:guid}")]
    public async Task<IActionResult> DeleteWorkoutSet(
        [FromRoute] Guid workoutSetId,
        CancellationToken ct = default)
    {
        var workoutSet = await workoutSetsRepository.GetByIdAsync(workoutSetId, ct);
        workoutSetsRepository.Delete(workoutSet);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }
}

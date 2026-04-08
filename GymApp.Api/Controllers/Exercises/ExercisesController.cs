using GymApp.Api.Controllers.Dtos;
using GymApp.Api.Repositories.Exercises;
using GymApp.Api.Repositories.UnitOfWork;
using GymApp.Shared.Models.Exercises.Dtos;
using GymApp.Shared.Models.Exercises.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers.Exercises;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController(
    IExercisesRepository exercisesRepository,
    IUnitOfWorkRepository unitOfWorkRepository)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetExercises(
        CancellationToken ct = default)
    {
        var exercises = await exercisesRepository.GetAsync(ct);
        var exercisesDto = exercises.Select(e =>
            new ExerciseDto(
                e.ExerciseId,
                e.Title,
                e.MuscleGroups,
                e.Equipment));

        return Ok(exercisesDto);
    }

    [HttpGet("{exerciseId:guid}")]
    public async Task<IActionResult> GetExerciseById(
        [FromRoute] Guid exerciseId,
        CancellationToken ct = default)
    {
        var exercise = await exercisesRepository.GetByIdAsync(exerciseId, ct);
        var exerciseDto = new ExerciseDto(
            exercise.ExerciseId,
            exercise.Title,
            exercise.MuscleGroups,
            exercise.Equipment);

        return Ok(exerciseDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateExercise(
        [FromBody] CreateExerciseDto dto,
        CancellationToken ct = default)
    {
        var exercise = Exercise.Create(dto);
        await exercisesRepository.CreateAsync(exercise, ct);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return CreatedAtAction(nameof(GetExerciseById), new { exerciseId = exercise.ExerciseId }, null);
    }

    [HttpPut("{exerciseId:guid}")]
    public async Task<IActionResult> UpdateExercise(
        [FromRoute] Guid exerciseId,
        [FromBody] UpdateExerciseDto dto,
        CancellationToken ct = default)
    {
        var exercise = await exercisesRepository.GetByIdAsync(exerciseId, ct);
        exercise.Update(dto);
        exercisesRepository.Update(exercise);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }

    [HttpDelete("{exerciseId:guid}")]
    public async Task<IActionResult> DeleteExercise(
        [FromRoute] Guid exerciseId,
        CancellationToken ct = default)
    {
        var exercise = await exercisesRepository.GetByIdAsync(exerciseId, ct);
        exercisesRepository.Delete(exercise);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }
}

namespace GymApp.Shared.Models.ExerciseSets.Dtos;

public record CreateWorkoutSetDto(
    Guid SessionId,
    Guid ExerciseId,
    float Weight,
    int? Reps,
    int? Duration,
    int RestTime);

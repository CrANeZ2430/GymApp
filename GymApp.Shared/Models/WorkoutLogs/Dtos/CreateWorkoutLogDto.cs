namespace GymApp.Shared.Models.WorkoutLogs.Dtos;

public record CreateWorkoutLogDto(
    Guid SessionId,
    Guid ExerciseId,
    float Weight,
    int Sets,
    int? Reps,
    int? Duration,
    int RestTime);

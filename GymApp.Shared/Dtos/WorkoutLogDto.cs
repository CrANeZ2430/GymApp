namespace GymApp.Shared.Dtos;

public record WorkoutLogDto(
    Guid WorkoutLogId,
    Guid ExerciseId,
    Guid SessionId,
    float Weight,
    int Sets,
    int? Reps,
    int? Duration,
    int RestTime);

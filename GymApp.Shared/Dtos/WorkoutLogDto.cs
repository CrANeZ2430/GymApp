namespace GymApp.Shared.Dtos;

public record WorkoutLogDto(
    Guid WorkoutLogId,
    Guid SessionId,
    ExerciseDto Exercise,
    float Weight,
    int Sets,
    int? Reps,
    int? Duration,
    int RestTime);

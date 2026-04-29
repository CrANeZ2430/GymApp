namespace GymApp.Shared.Dtos;

public record WorkoutLogDto(
    Guid WorkoutLogId,
    ExerciseDto Exercise,
    SessionDto Session,
    float Weight,
    int Sets,
    int? Reps,
    int? Duration,
    int RestTime);

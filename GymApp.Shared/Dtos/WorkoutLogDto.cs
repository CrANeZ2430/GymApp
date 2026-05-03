namespace GymApp.Shared.Dtos;

public record WorkoutLogDto(
    Guid WorkoutLogId,
    Guid SessionId,
    ExerciseDto Exercises,
    float Weight,
    int Sets,
    int? Reps,
    int? Duration,
    int RestTime);

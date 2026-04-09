namespace GymApp.Shared.Dtos;

public record WorkoutSetDto(
    Guid WorkoutRepId,
    ExerciseDto Exercise,
    SessionDto Session,
    float Weight,
    int? Reps,
    int? Duration,
    int RestTime,
    DateTime DoneAt);

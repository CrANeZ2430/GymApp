namespace GymApp.Shared.Dtos;

public record WorkoutSetDto(
    Guid WorkoutSetId,
    ExerciseDto Exercise,
    SessionDto Session,
    float Weight,
    int? Reps,
    int? Duration,
    int RestTime,
    DateTime DoneAt);

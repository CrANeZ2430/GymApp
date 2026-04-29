namespace GymApp.Shared.Models.WorkoutLogs.Dtos;

public record UpdateWorkoutLogDto(
    float Weight,
    int Sets,
    int? Reps,
    int? Dutation,
    int RestTime);

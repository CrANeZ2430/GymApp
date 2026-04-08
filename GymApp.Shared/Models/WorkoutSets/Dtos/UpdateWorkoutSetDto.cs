namespace GymApp.Shared.Models.WorkoutSets.Dtos;

public record UpdateWorkoutSetDto(
    float Weight,
    int? Reps,
    int? Dutation,
    int RestTime);

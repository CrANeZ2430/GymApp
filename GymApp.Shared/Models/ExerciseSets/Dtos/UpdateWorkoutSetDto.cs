namespace GymApp.Shared.Models.ExerciseSets.Dtos;

public record UpdateWorkoutSetDto(
    float Weight,
    int? Reps,
    int? Dutation,
    int RestTime);

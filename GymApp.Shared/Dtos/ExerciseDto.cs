using GymApp.Shared.Models.Exercises.Models;

namespace GymApp.Shared.Dtos;

public record ExerciseDto(
    Guid ExerciseId,
    string Title,
    MuscleGroups MuscleGroups,
    Equipment Equipment);

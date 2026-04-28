using GymApp.Shared.Models.Exercises.Models;

namespace GymApp.Shared.Dtos;

public record ExerciseDto(
    Guid ExerciseId,
    string Name,
    MuscleGroups MuscleGroups,
    Equipment Equipment);

using GymApp.Shared.Models.Exercises.Models;

namespace GymApp.Shared.Models.Exercises.Dtos;

public record UpdateExerciseDto(
    string Name,
    MuscleGroups MuscleGroups,
    Equipment Equipment);

using GymApp.Shared.Models.Exercises.Models;

namespace GymApp.Shared.Models.Exercises.Dtos;

public record CreateExerciseDto(
    string Name,
    MuscleGroups MuscleGroups,
    Equipment Equipment);
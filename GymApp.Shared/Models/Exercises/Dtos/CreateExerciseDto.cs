using GymApp.Shared.Models.Exercises.Models;

namespace GymApp.Shared.Models.Exercises.Dtos;

public record CreateExerciseDto(
    string Title,
    MuscleGroups MuscleGroups,
    Equipment Equipment);
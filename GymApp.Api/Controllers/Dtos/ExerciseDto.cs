using GymApp.Shared.Models.Exercises.Models;

namespace GymApp.Api.Controllers.Dtos;

public record ExerciseDto(
    Guid ExerciseId,
    string Title,
    MuscleGroups MuscleGroups,
    Equipment Equipment);

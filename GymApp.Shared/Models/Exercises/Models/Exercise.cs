using GymApp.Shared.Models.Exercises.Dtos;
using GymApp.Shared.Models.ExerciseSets.Models;

namespace GymApp.Shared.Models.Exercises.Models;

public class Exercise
{
    private readonly List<WorkoutSet> _workoutSets = new();

    public Guid ExerciseId { get; private set; }
    public string Title { get; private set; }
    public MuscleGroups MuscleGroups { get; private set; }
    public Equipment Equipment { get; private set; }

    public ICollection<WorkoutSet> WorkoutSets => _workoutSets;
    
    private Exercise() { }

    private Exercise(string title, MuscleGroups muscleGroups, Equipment equipment)
    {
        ExerciseId = Guid.NewGuid();
        Title = title;
        MuscleGroups = muscleGroups;
        Equipment = equipment;
    }

    public static Exercise Create(CreateExerciseDto dto)
    {
        return new Exercise(dto.Title,
            dto.MuscleGroups,
            dto.Equipment);
    }

    public void Update(UpdateExerciseDto dto)
    {
        Title = dto.Title;
        MuscleGroups = dto.MuscleGroups;
        Equipment = dto.Equipment;
    }
}

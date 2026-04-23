using GymApp.Shared.Models.Exercises.Dtos;
using GymApp.Shared.Models.WorkoutSets.Models;

namespace GymApp.Shared.Models.Exercises.Models;

public class Exercise
{
    private readonly List<WorkoutSet> _workoutSets = new();

    public Guid ExerciseId { get; private set; }
    public string Name { get; private set; }
    public MuscleGroups MuscleGroups { get; private set; }
    public Equipment Equipment { get; private set; }

    public ICollection<WorkoutSet> WorkoutSets => _workoutSets;
    
    private Exercise() { }

    private Exercise(string name, MuscleGroups muscleGroups, Equipment equipment)
    {
        ExerciseId = Guid.NewGuid();
        Name = name;
        MuscleGroups = muscleGroups;
        Equipment = equipment;
    }

    public static Exercise Create(CreateExerciseDto dto)
    {
        return new Exercise(dto.Name,
            dto.MuscleGroups,
            dto.Equipment);
    }

    public void Update(UpdateExerciseDto dto)
    {
        Name = dto.Name;
        MuscleGroups = dto.MuscleGroups;
        Equipment = dto.Equipment;
    }
}

using GymApp.Shared.Models.Exercises.Models;
using GymApp.Shared.Models.WorkoutSets.Dtos;
using GymApp.Shared.Models.Sessions.Models;

namespace GymApp.Shared.Models.WorkoutSets.Models;

public class WorkoutSet
{
    public Guid WorkoutSetId { get; private set; }
    public Guid SessionId { get; private set; }
    public Guid ExerciseId { get; private set; }
    public float Weight { get; private set; }
    public int? Reps { get; private set; }
    public int? Duration { get; private set; }
    public int RestTime { get; private set; }
    public DateTime DoneAt { get; private set; }

    public Session Session { get; private set; }
    public Exercise Exercise { get; private set; }

    private WorkoutSet() { }

    private WorkoutSet(Guid sessionId, Guid exerciseId, float weight, int? reps, int? duration, int restTime)
    {
        SessionId = sessionId;
        ExerciseId = exerciseId;
        Weight = weight;
        Reps = reps;
        Duration = duration;
        RestTime = restTime;
        DoneAt = DateTime.UtcNow;
    }

    public static WorkoutSet Create(CreateWorkoutSetDto dto)
    {
        return new WorkoutSet(
            dto.SessionId,
            dto.ExerciseId,
            dto.Weight,
            dto.Reps,
            dto.Duration,
            dto.RestTime);
    }

    public void Update(UpdateWorkoutSetDto dto)
    {
        Weight = dto.Weight;
        Reps = dto.Reps;
        Duration = dto.Dutation;
        RestTime = dto.RestTime;
    }
}

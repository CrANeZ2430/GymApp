using GymApp.Shared.Models.Exercises.Models;
using GymApp.Shared.Models.WorkoutLogs.Dtos;
using GymApp.Shared.Models.Sessions.Models;

namespace GymApp.Shared.Models.WorkoutLogs.Models;

public class WorkoutLog
{
    public Guid WorkoutLogId { get; private set; }
    public Guid SessionId { get; private set; }
    public Guid ExerciseId { get; private set; }
    public float Weight { get; private set; }
    public int Sets { get; private set; }
    public int? Reps { get; private set; }
    public int? Duration { get; private set; }
    public int RestTime { get; private set; }

    public Session Session { get; private set; }
    public Exercise Exercise { get; private set; }

    private WorkoutLog() { }

    private WorkoutLog(Guid sessionId, Guid exerciseId, float weight, 
        int sets, int? reps, int? duration, int restTime)
    {
        WorkoutLogId = Guid.NewGuid();
        SessionId = sessionId;
        ExerciseId = exerciseId;
        Weight = weight;
        Sets = sets;
        Reps = reps;
        Duration = duration;
        RestTime = restTime;
    }

    public static WorkoutLog Create(CreateWorkoutLogDto dto)
    {
        return new WorkoutLog(
            dto.SessionId,
            dto.ExerciseId,
            dto.Weight,
            dto.Sets,
            dto.Reps,
            dto.Duration,
            dto.RestTime);
    }

    public void Update(UpdateWorkoutLogDto dto)
    {
        Weight = dto.Weight;
        Sets = dto.Sets;
        Reps = dto.Reps;
        Duration = dto.Dutation;
        RestTime = dto.RestTime;
    }
}

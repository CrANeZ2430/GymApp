using GymApp.Shared.Models.AppUsers.Models;
using GymApp.Shared.Models.ExerciseSets.Models;
using GymApp.Shared.Models.Sessions.Dtos;

namespace GymApp.Shared.Models.Sessions.Models;

public class Session
{
    private readonly List<WorkoutSet> _workoutSets = new();

    public Guid SessionId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime Date { get; private set; }
    public string Note { get; private set; }

    public AppUser AppUser { get; private set; }
    public ICollection<WorkoutSet> WorkoutSets => _workoutSets;

    private Session() { }

    private Session(Guid userId, DateTime date, string note)
    {
        SessionId = Guid.NewGuid();
        UserId = userId;
        Date = date;
        Note = note;
    }

    public static Session Create(CreateSessionDto dto)
    {
        return new Session(
            dto.UserId,
            dto.Date,
            dto.Note);
    }

    public void Update(UpdateSessionDto dto)
    {
        Date = dto.Date;
        Note = dto.Note;
    }
}

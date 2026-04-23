using GymApp.Shared.Models.AppUsers.Models;
using GymApp.Shared.Models.WorkoutSets.Models;
using GymApp.Shared.Models.Sessions.Dtos;

namespace GymApp.Shared.Models.Sessions.Models;

public class Session
{
    private readonly List<WorkoutSet> _workoutSets = new();

    public Guid SessionId { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    public DateTime Date { get; private set; }
    public string Note { get; private set; }
    public bool IsDefault { get; private set; }

    public AppUser AppUser { get; private set; }
    public ICollection<WorkoutSet> WorkoutSets => _workoutSets;

    private Session() { }

    private Session(Guid userId, string name, DateTime date, string note, bool isDefault)
    {
        SessionId = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Date = date;
        Note = note;
        IsDefault = isDefault;
    }

    public static Session Create(CreateSessionDto dto)
    {
        return new Session(
            dto.UserId,
            dto.Name,
            dto.Date,
            dto.Note,
            dto.IsDefault);
    }

    public void Update(UpdateSessionDto dto)
    {
        Name = dto.Name;
        Date = dto.Date;
        Note = dto.Note;
        IsDefault = dto.IsDefault;
    }
}

using GymApp.Shared.Models.AppUsers.Dtos;
using GymApp.Shared.Models.Sessions.Models;

namespace GymApp.Shared.Models.AppUsers.Models;

public class AppUser
{
    private readonly List<Session> _sessions = new();

    public Guid AppUserId { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public int Age { get; private set; }

    public ICollection<Session> Sessions => _sessions;

    private AppUser() { }

    private AppUser(string userName, string email, int age)
    {
        AppUserId = Guid.NewGuid();
        UserName = userName;
        Email = email;
        Age = age;
    }

    public static AppUser Create(CreateAppUserDto dto)
    {
        return new AppUser(
            dto.UserName,
            dto.Email,
            dto.Age);
    }

    public void Update(UpdateAppUserDto dto)
    {
        UserName = dto.UserName;
        Email = dto.Email;
        Age = dto.Age;
    }
}

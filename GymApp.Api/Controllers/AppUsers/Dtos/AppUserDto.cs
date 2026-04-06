namespace GymApp.Api.Controllers.AppUsers.Dtos;

public record AppUserDto(
    Guid AppUserId,
    string UserName,
    string Email,
    int Age);

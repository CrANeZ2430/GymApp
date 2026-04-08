namespace GymApp.Api.Controllers.Dtos;

public record AppUserDto(
    Guid AppUserId,
    string UserName,
    string Email,
    int Age);

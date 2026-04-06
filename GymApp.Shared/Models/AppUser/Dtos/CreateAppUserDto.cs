namespace GymApp.Shared.Models.AppUsers.Dtos;

public record CreateAppUserDto(
    string UserName,
    string Email,
    int Age);

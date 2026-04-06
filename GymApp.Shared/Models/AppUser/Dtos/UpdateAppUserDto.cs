namespace GymApp.Shared.Models.AppUsers.Dtos;

public record UpdateAppUserDto(
    string UserName,
    string Email,
    int Age);

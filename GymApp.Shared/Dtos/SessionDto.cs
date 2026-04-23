namespace GymApp.Shared.Dtos;

public record SessionDto(
    Guid SessionId,
    AppUserDto AppUserDto,
    string Name,
    DateTime Date,
    string Note,
    bool IsDefault);

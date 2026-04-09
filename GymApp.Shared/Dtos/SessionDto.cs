namespace GymApp.Shared.Dtos;

public record SessionDto(
    Guid SessionId,
    AppUserDto AppUserDto,
    DateTime Date,
    string Note);

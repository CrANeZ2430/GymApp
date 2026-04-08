namespace GymApp.Api.Controllers.Dtos;

public record SessionDto(
    Guid SessionId,
    AppUserDto AppUserDto,
    DateTime Date,
    string Note);

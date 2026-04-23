namespace GymApp.Shared.Models.Sessions.Dtos;

public record CreateSessionDto(
    Guid UserId,
    string Name,
    DateTime Date,
    string Note,
    bool IsDefault);

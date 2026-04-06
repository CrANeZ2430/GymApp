namespace GymApp.Shared.Models.Sessions.Dtos;

public record CreateSessionDto(
    Guid UserId,
    DateTime Date,
    string Note);

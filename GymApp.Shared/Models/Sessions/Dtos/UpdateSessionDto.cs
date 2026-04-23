namespace GymApp.Shared.Models.Sessions.Dtos;

public record UpdateSessionDto(
    string Name,
    DateTime Date,
    string Note,
    bool IsDefault);

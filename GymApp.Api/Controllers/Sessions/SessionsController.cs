using GymApp.Shared.Dtos;
using GymApp.Api.Repositories.Sessions;
using GymApp.Api.Repositories.UnitOfWork;
using GymApp.Shared.Models.Sessions.Dtos;
using GymApp.Shared.Models.Sessions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers.Sessions;

[Route("api/[controller]")]
[ApiController]
public class SessionsController(
    ISessionsRepository sessionsRepository,
    IUnitOfWorkRepository unitOfWorkRepository) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSessions(
        CancellationToken ct = default)
    {
        var sessions = await sessionsRepository.GetAsync(ct);
        var sessionsDto = sessions.Select(s => 
            new SessionDto(
                s.SessionId,
                new AppUserDto(
                    s.AppUser.AppUserId,
                    s.AppUser.UserName,
                    s.AppUser.Email,
                    s.AppUser.Age),
                s.Name,
                s.Date,
                s.Note,
                s.IsDefault));

        return Ok(sessionsDto);
    }

    [HttpGet("{sessionId:guid}")]
    public async Task<IActionResult> GetSessionById(
        [FromRoute] Guid sessionId,
        CancellationToken ct = default)
    {
        var session = await sessionsRepository.GetByIdAsync(sessionId, ct);
        var sessionDto = new SessionDto(
            session.SessionId,
            new AppUserDto(
                session.AppUser.AppUserId,
                session.AppUser.UserName,
                session.AppUser.Email,
                session.AppUser.Age),
            session.Name,
            session.Date,
            session.Note,
            session.IsDefault);

        return Ok(sessionDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSession(
        [FromBody] CreateSessionDto dto,
        CancellationToken ct = default)
    {
        var session = Session.Create(dto);
        await sessionsRepository.CreateAsync(session, ct);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return CreatedAtAction(nameof(GetSessionById), new { sessionId = session.SessionId }, null);
    }

    [HttpPut("{sessionId:guid}")]
    public async Task<IActionResult> UpdateSession(
        [FromRoute] Guid sessionId,
        [FromBody] UpdateSessionDto dto,
        CancellationToken ct = default)
    {
        var session = await sessionsRepository.GetByIdAsync(sessionId, ct);
        session.Update(dto);
        sessionsRepository.Update(session);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }

    [HttpDelete("{sessionId:guid}")]
    public async Task<IActionResult> DeleteSession(
        [FromRoute] Guid sessionId,
        CancellationToken ct = default)
    {
        var session = await sessionsRepository.GetByIdAsync(sessionId, ct);
        sessionsRepository.Delete(session);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }
}

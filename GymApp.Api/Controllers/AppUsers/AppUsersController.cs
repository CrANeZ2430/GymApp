using GymApp.Shared.Dtos;
using GymApp.Api.Repositories.AppUsers;
using GymApp.Api.Repositories.UnitOfWork;
using GymApp.Shared.Models.AppUsers.Dtos;
using GymApp.Shared.Models.AppUsers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers.AppUsers;

[Route("api/[controller]")]
[ApiController]
public class AppUsersController(
    IAppUsersRepository appUsersRepository, 
    IUnitOfWorkRepository unitOfWorkRepository) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAppUsers(
        CancellationToken ct = default)
    {
        var appUsers = await appUsersRepository.GetAsync(ct);
        var appUsersDto = appUsers.Select(au => 
            new AppUserDto(
                au.AppUserId,
                au.UserName,
                au.Email,
                au.Age));

        return Ok(appUsersDto);
    }

    [HttpGet("{appUserId:guid}")]
    public async Task<IActionResult> GetUserById(
        [FromRoute] Guid appUserId,
        CancellationToken ct = default)
    {
        var appUser = await appUsersRepository.GetByIdAsync(appUserId, ct);
        var appUserDto = new AppUserDto(
            appUser.AppUserId,
            appUser.UserName,
            appUser.Email,
            appUser.Age);

        return Ok(appUserDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateAppUserDto dto,
        CancellationToken ct = default)
    {
        var appUser = AppUser.Create(dto);
        await appUsersRepository.CreateAsync(appUser, ct);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return CreatedAtAction(nameof(GetUserById), new { appUserId = appUser.AppUserId }, null);
    }

    [HttpPut("{appUserId:guid}")]
    public async Task<IActionResult> UpdateUser(
        [FromRoute] Guid appUserId,
        [FromBody] UpdateAppUserDto dto,
        CancellationToken ct = default)
    {
        var appUser = await appUsersRepository.GetByIdAsync(appUserId, ct);
        appUser.Update(dto);
        appUsersRepository.UpdateAsync(appUser);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }

    [HttpDelete("{appUserId:guid}")]
    public async Task<IActionResult> DeleteUser(
        [FromRoute] Guid appUserId,
        CancellationToken ct = default)
    {
        var appUser = await appUsersRepository.GetByIdAsync(appUserId, ct);
        appUsersRepository.DeleteAsync(appUser);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return NoContent();
    }
}

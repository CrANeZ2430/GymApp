using GymApp.Api.Controllers.AppUsers.Dtos;
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
    IUnitOfWorkRepository unitOfWorkRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAppUsers(
        CancellationToken ct = default)
    {
        var appUsers = await appUsersRepository.GetUsers();

        return Ok(appUsers);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateAppUserDto dto,
        CancellationToken ct = default)
    {
        var appUser = AppUser.Create(dto);
        await appUsersRepository.Create(appUser, ct);
        await unitOfWorkRepository.SaveChangesAsync(ct);

        return Ok();
    }
}

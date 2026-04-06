using GymApp.Api.Repositories.AppUsers;
using GymApp.Api.Repositories.UnitOfWork;

namespace GymApp.Api.Repositories;

public static class RepositoriesRegistration
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
        services.AddScoped<IAppUsersRepository, AppUsersRepository>();
    }
}

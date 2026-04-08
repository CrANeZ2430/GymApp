using GymApp.Api.Repositories.AppUsers;
using GymApp.Api.Repositories.Exercises;
using GymApp.Api.Repositories.Sessions;
using GymApp.Api.Repositories.UnitOfWork;
using GymApp.Api.Repositories.WorkoutSets;

namespace GymApp.Api.Repositories;

public static class RepositoriesRegistration
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
        services.AddScoped<IAppUsersRepository, AppUsersRepository>();
        services.AddScoped<ISessionsRepository, SessionsRepository>();
        services.AddScoped<IExercisesRepository, ExercisesRepository>();
        services.AddScoped<IWorkoutSetsRepository, WorkoutSetsRepository>();
    }
}

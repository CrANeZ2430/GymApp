using GymApp.Visual.Constants;
using GymApp.Visual.Services.Exercises;
using GymApp.Visual.Services.Sessions;
using GymApp.Visual.Services.WorkoutLogs;

namespace GymApp.Visual.Services;

public static class ServicesRegistration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddHttpClient<IExercisesService, ExercisesService>(client =>
        {
            client.BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android
                ? GymAppConstants.BASE_URL_ANDROID
                : GymAppConstants.BASE_URL);
        });
        services.AddHttpClient<ISessionsService, SessionsService>(client =>
        {
            client.BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android
                ? GymAppConstants.BASE_URL_ANDROID
                : GymAppConstants.BASE_URL);
        });
        services.AddHttpClient<IWorkoutLogsService, WorkoutLogsService>(client =>
        {
            client.BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android
                ? GymAppConstants.BASE_URL_ANDROID
                : GymAppConstants.BASE_URL);
        });
    }
}

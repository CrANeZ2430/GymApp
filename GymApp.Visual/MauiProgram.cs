using GymApp.Visual.Constants;
using GymApp.Visual.Services;
using GymApp.Visual.Services.Exercises;
using GymApp.Visual.Services.Sessions;
using GymApp.Visual.View;
using GymApp.Visual.ViewModels;
using Microsoft.Extensions.Logging;

namespace GymApp.Visual
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddHttpClient<IExercisesService, ExercisesService>(client =>
            {
                client.BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android
                    ? GymAppConstants.BASE_URL_ANDROID
                    : GymAppConstants.BASE_URL);
            });
            builder.Services.AddHttpClient<ISessionsService, SessionsService>(client =>
            {
                client.BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android
                    ? GymAppConstants.BASE_URL_ANDROID
                    : GymAppConstants.BASE_URL);
            });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<ExercisesPage>();
            builder.Services.AddTransient<ExercisesViewModel>();

            builder.Services.AddTransient<AddExercisePage>();
            builder.Services.AddTransient<AddExerciseViewModel>();

            builder.Services.AddTransient<WorkoutsPage>();
            builder.Services.AddTransient<WorkoutsViewModel>();

            builder.Services.AddTransient<AddSessionPage>();
            builder.Services.AddTransient<AddSessionViewModel>();

            builder.Services.AddTransient<SessionDetailsPage>();
            builder.Services.AddTransient<SessionDetailsViewModel>();

            return builder.Build();
        }
    }
}

using GymApp.Visual.Constants;
using GymApp.Visual.Services;
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

            builder.Services.AddHttpClient<GymAppService>(client =>
            {
                client.BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android
                    ? GymAppConstants.BASE_URL_ANDROID
                    : GymAppConstants.BASE_URL);
            });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<ExercisesPage>();
            builder.Services.AddTransient<ExercisesViewModel>();
            builder.Services.AddTransient<AddExercisePage>();
            builder.Services.AddTransient<AddExerciseViewModel>();

            return builder.Build();
        }
    }
}

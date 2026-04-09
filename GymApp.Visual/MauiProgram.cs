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
                    ? "http://10.0.2.2:5264/api/"
                    : "http://localhost:5264/api/");
            });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ExercisesViewModel>();

            return builder.Build();
        }
    }
}

using GymApp.Visual.Services;
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
                    ? "https://10.0.2.2:7267/api/"
                    : "https://localhost:7267/api/");
            });

            return builder.Build();
        }
    }
}

using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Services;
using GymApp.Visual.Services;
using GymApp.Visual.Services.Exercises;
using GymApp.Visual.Services.Sessions;
using GymApp.Visual.ViewModels;
using GymApp.Visual.Views;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.RegisterServices();

            builder.Services.RegisterViewModels();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ExercisesPage>();
            builder.Services.AddTransient<AddExercisePage>();
            builder.Services.AddTransient<WorkoutsPage>();
            builder.Services.AddTransient<AddSessionPage>();
            builder.Services.AddTransient<SessionDetailsPage>();
            builder.Services.AddTransient<AddWorkoutLogPopup>();

            builder.Services.AddSingleton<IPopupService, PopupService>();

            return builder.Build();
        }
    }
}

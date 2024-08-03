using CommunityToolkit.Maui;
using Kwops.Mobile;
using KWops.Mobile.Services;
using KWops.Mobile.Services.Identity;
using KWops.Mobile.Settings;
using KWops.Mobile.ViewModels;
using Kwops.Mobile.Views;

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

        RegisterDependencies(builder.Services);

        return builder.Build();
    }

    private static void RegisterDependencies(IServiceCollection services)
    {
        // Views
        services.AddTransient<LoginPage>();

        // ViewModels
        services.AddTransient<LoginViewModel>();

        // Services
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<INavigationService, NavigationService>();
        services.AddTransient<IToastService, ToastService>();

        // Other
        services.AddSingleton<ITokenProvider, TokenProvider>();
        services.AddSingleton<IAppSettings, DevAppSettings>();
    }
}
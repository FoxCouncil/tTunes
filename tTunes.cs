using LibVLCSharp;
using Microsoft.Extensions.DependencyInjection;

namespace tTunes;

internal static class tTunes
{
#pragma warning disable CS8618 // Only null for LibVLC to load its libs
    public static LibVLC LibVLC;
    public static MediaPlayer Player;
#pragma warning restore CS8618 

    [STAThread]
    static void Main()
    {
        // App Init
        Core.Initialize(); // LibVLC
        LibVLC = new LibVLC();
        Player = new MediaPlayer(LibVLC);

        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();

        ConfigureServices(services);

        using var serviceProvider = services.BuildServiceProvider();

        var mainForm = serviceProvider.GetService<MainForm>() ?? throw new Exception("Cannot inject main form!");

        Application.Run(mainForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // services.AddTransient<>();
        services.AddScoped<MainForm>();
    }
}
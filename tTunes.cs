using LibVLCSharp;
using Microsoft.Extensions.DependencyInjection;

namespace tTunes;

internal static class tTunes
{
    static readonly string[] SizeSuffixes = ["bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"];

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
        services.AddScoped<Config>();
        services.AddScoped<MainForm>();
    }

    public static string SizeSuffix(this ulong value, int decimalPlaces = 1)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(decimalPlaces);

        if (value == 0) { 
            return string.Format("{0:n" + decimalPlaces + "} bytes", 0); 
        }

        var mag = (int)Math.Log(value, 1024);
        var adjustedSize = (decimal)value / (1L << (mag * 10));

        if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
        {
            mag += 1;
            adjustedSize /= 1024;
        }

        return string.Format("{0:n" + decimalPlaces + "} {1}", adjustedSize, SizeSuffixes[mag]);
    }
}
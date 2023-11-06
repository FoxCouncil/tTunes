using LibVLCSharp;
using System.Text;

namespace tTunes.Models;

internal class TrackerFile
{
    static LibVLC LibVLC => tTunes.LibVLC;

    internal string Path { get; }

    internal long Duration { get; }

    public string Title => GetTitle();

    public string Name { get; }

    public string Year { get; private set; }

    public string Time { get; private set; }

    public string Type { get; }

    public TrackerFile(string path)
    {
        Path = path;
        Name = path.Split('\\').Last().Split(".").First();
        Type = path.Split(".").Last().ToUpper();
        Year = "0";
        Time = "00:00:00";
    }

    public string GetTitle()
    {
        using var media = new Media(Path);

        media.ParseAsync(LibVLC).Wait();

        Time = TimeSpan.FromMilliseconds(media.Duration).ToString("hh\\:mm\\:ss");

        media.FileStat(FileStat.Mtime, out var date);

        var dateTime = DateTimeOffset.FromUnixTimeSeconds((long)date);

        Year = dateTime.Year.ToString();

        return media.Meta(MetadataType.Title) ?? "N/A";
    }
}


using LibVLCSharp;

namespace tTunes.Models;

internal class TrackerFile(string path)
{
    static LibVLC LibVLC => tTunes.LibVLC;

    internal string Path { get; } = path;

    internal long Duration { get; }

    public string Title => GetTitle();

    public string Name { get; } = path.Split('\\').Last().Split(".").First();

    public string Year { get; private set; } = "0";

    public string Time { get; private set; } = "00:00:00";

    public string Size { get; private set; } = "0";

    public string Type { get; } = path.Split(".").Last().ToUpper();

    public string GetTitle()
    {
        using var media = new Media(Path);

        media.ParseAsync(LibVLC).Wait();

        Time = TimeSpan.FromMilliseconds(media.Duration).ToString("hh\\:mm\\:ss");

        media.FileStat(FileStat.Mtime, out var date);

        var dateTime = DateTimeOffset.FromUnixTimeSeconds((long)date);

        Year = dateTime.Year.ToString();

        media.FileStat(FileStat.Size, out var size);

        Size = size.SizeSuffix();

        return media.Meta(MetadataType.Title) ?? "N/A";
    }
}


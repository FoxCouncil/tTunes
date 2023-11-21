using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using tTunes.Models;

namespace tTunes;

public class Config
{
    readonly string Name = "tTunes.json";

    readonly string Path;

    public Settings Settings;

    public Config() 
    {
        var directory = System.IO.Path.GetDirectoryName(Application.ExecutablePath) ?? throw new ApplicationException("Path File Failure");

        Path = System.IO.Path.Combine(directory, Name);

        Settings = new()
        {
            Directory = directory,
            SelectionIndex = 0
        };

        if (!File.Exists(Path))
        {
            Save();
        }
        else
        {
            Load();
        }
    }

    public void Save()
    {
        var configJsonString = JsonSerializer.Serialize(Settings);

        File.WriteAllText(Path, configJsonString);
    }

    public void Load()
    {
        var configJsonString = File.ReadAllText(Path);

        Settings = JsonSerializer.Deserialize<Settings>(configJsonString) ?? throw new ApplicationException("Corrupt config file!");
    }
}

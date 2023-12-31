using LibVLCSharp;
using System.Diagnostics;
using System.Runtime.InteropServices;
using tTunes.Models;

namespace tTunes;

public partial class MainForm : Form
{
    [DllImport("user32")]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    const int WM_KEYDOWN = 0x100;
    const int WM_KEYUP = 0x101;

    static MediaPlayer Player => tTunes.Player;

    readonly List<string> allowListedExtensions = [".669", ".IT", ".MED", ".MOD", ".MTM", ".S3M", ".STM", ".XM"];

    readonly string playerName;

    readonly Config config;

    int currentSelectedIndex = -1;

    Color oldColor;

    bool isPlaying;
    bool isTrackBarInUse;
    bool isTrackBarBeingScrolled;

    public MainForm(Config configuration)
    {
        InitializeComponent();

        config = configuration;

        playerName = Text;

        libraryGridView.DataSource = libraryDataSource;

        iconButtonPreviousTrack.Enabled = false;
        iconButtonPlay.Enabled = false;
        iconButtonPause.Enabled = false;
        iconButtonStop.Enabled = false;
        iconButtonNextTrack.Enabled = false;

        KeyDown += (s, e) => HandleKeyboard(e);

        iconButtonReloadLibrary.Click += (s, e) => LoadTrackerLibrary(config.Settings.Directory);
        iconButtonPreviousTrack.Click += (s, e) => { PreviousTrack(); ActiveControl = libraryGridView; };
        iconButtonPlay.Click += (s, e) => { if (Player.Media == null) { LibraryPlaySelection(true); } else ThreadPool.QueueUserWorkItem(_ => Player.Play()); ActiveControl = libraryGridView; };
        iconButtonPause.Click += (s, e) => { ThreadPool.QueueUserWorkItem(_ => Player.Pause()); ActiveControl = libraryGridView; };
        iconButtonStop.Click += (s, e) => { ThreadPool.QueueUserWorkItem(_ => Player.Stop()); ActiveControl = libraryGridView; };
        iconButtonNextTrack.Click += (s, e) => { NextTrack(); ActiveControl = libraryGridView; };
        iconButtonSelectDirectory.Click += (s, e) => 
        {
            var folderChooser = new FolderBrowserDialog
            {
                InitialDirectory = config.Settings.Directory
            };

            var dialogResult = folderChooser.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                var folder = folderChooser.SelectedPath;

                config.Settings.SelectionIndex = 0;
                config.Settings.Directory = folder;
                config.Save();

                LoadTrackerLibrary(config.Settings.Directory);
            }
        };

        trackBarTime.MouseDown += (s, e) => 
        {
            if (s is not TrackBar trackBar)
            {
                return;
            }

            int thumbWidth = GetThumbWidth(trackBar);
            int thumbHeight = trackBar.Size.Height;
            int thumbLeft = GetThumbLeftPosition(trackBar, thumbWidth);
            int thumbTop = 0;

            var thumbRect = new Rectangle(thumbLeft, thumbTop, thumbWidth, thumbHeight);

            isTrackBarBeingScrolled = thumbRect.Contains(e.Location);

            isTrackBarInUse = true; 
        };
        trackBarTime.MouseUp += (s, e) => 
        {
            if (s is not TrackBar trackBar)
            {
                return;
            }

            if (isTrackBarBeingScrolled)
            {
                if (Player.Time == trackBar.Value)
                {
                    return;
                }

                var newValue = trackBar.Value;

                ThreadPool.QueueUserWorkItem(_ => Player.SeekTo(TimeSpan.FromMilliseconds(newValue), true));

                isTrackBarBeingScrolled = false;
            }

            isTrackBarInUse = false;
        };
        trackBarTime.KeyDown += (s, e) => HandleKeyboard(e);

        libraryGridView.MouseDoubleClick += (s, e) => LibraryPlaySelection(true);
        libraryGridView.KeyDown += (s, e) => HandleKeyboard(e);

        Player.MediaChanged += (s, e) => Invoke(() =>
        {
            if (e.Media.ParsedStatus != MediaParsedStatus.Done)
            {
                e.Media.ParseAsync(tTunes.LibVLC).Wait();
            }

            labelTitle.Text = e.Media.Meta(MetadataType.Title) ?? e.Media.Mrl;

            e.Media.FileStat(FileStat.Mtime, out var date);

            var dateTime = DateTimeOffset.FromUnixTimeSeconds((long)date);

            labelYear.Text = dateTime.Year.ToString();

            labelFileType.Text = e.Media.Mrl.Split(".").Last().ToUpper();

            var duration = (int)e.Media.Duration;

            labelTimeTotal.Text = TimeSpan.FromMilliseconds(duration).ToString("mm\\:ss");
            labelTimeCurrent.Text = "00:00";

            trackBarTime.Maximum = duration;
            trackBarTime.Value = 0;
        });
        Player.Playing += (s, e) => Invoke(() =>
        {
            isPlaying = true;

            labelPlaybackStatusText.Text = "PLAYING";

            iconButtonPlay.Enabled = false;
            iconButtonPause.Enabled = true;
            iconButtonStop.Enabled = true;

            trackBarTime.Value = 0;
        });
        Player.TimeChanged += (s, e) => Invoke(() =>
        {
            labelTimeCurrent.Text = TimeSpan.FromMilliseconds(e.Time).ToString("mm\\:ss");

            if (!isTrackBarInUse)
            {
                trackBarTime.Value = (int)Math.Clamp(e.Time, 0, trackBarTime.Maximum);
            }

            if (e.Time >= trackBarTime.Maximum)
            {
                NextTrack();
            }
        });
        Player.Stopped += (s, e) => Invoke(() =>
        {
            isPlaying = false;

            labelPlaybackStatusText.Text = "STOPPED";

            labelTimeCurrent.Text = "00:00";

            iconButtonPlay.Enabled = true;
            iconButtonPause.Enabled = false;
            iconButtonStop.Enabled = false;

            trackBarTime.Value = 0;
        });
        Player.Paused += (s, e) => Invoke(() =>
        {
            isPlaying = false;

            labelPlaybackStatusText.Text = "PAUSED";

            iconButtonPlay.Enabled = true;
            iconButtonPause.Enabled = false;
            iconButtonStop.Enabled = true;
        });

        Shown += (s, e) => LoadTrackerLibrary(config.Settings.Directory);
    }

    private void HandleKeyboard(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            LibraryPlaySelection(true);

            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        else if (e.KeyCode == Keys.Escape)
        {
            ThreadPool.QueueUserWorkItem(_ => Player.Stop());
        }
        else if (e.KeyCode == Keys.Space)
        {
            ThreadPool.QueueUserWorkItem(_ => { if (Player.IsPlaying) Player.Pause(); else Player.Play(); });
        }
        else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp)
        {
            if (!libraryGridView.Focused)
            {
                libraryGridView.Focus();

                SendMessage(libraryGridView.Handle, WM_KEYDOWN, (IntPtr)e.KeyCode, IntPtr.Zero);
                SendMessage(libraryGridView.Handle, WM_KEYUP, (IntPtr)e.KeyCode, IntPtr.Zero);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
        {
            var delta = trackBarTime.Value + (e.KeyCode == Keys.Left ? -1000 : 1000);

            Debug.WriteLine($"V: {trackBarTime.Value} - D: {delta}");

            trackBarTime.Value = delta;

            ThreadPool.QueueUserWorkItem(_ => Player.SeekTo(TimeSpan.FromMilliseconds(delta), true));

            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        else if (e.KeyCode == Keys.OemPeriod)
        {
            NextTrack();
        }
        else if (e.KeyCode == Keys.Oemcomma)
        {
            PreviousTrack();
        }
        else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
        {
            var letter = (char)e.KeyCode;

            var files = libraryDataSource.DataSource as List<TrackerFile> ?? throw new ApplicationException("DataSource Failure");

            var index = files.FindIndex(file => Path.GetFileName(file.Path).ToUpper()[0] == letter);

            libraryGridView.CurrentCell = libraryGridView.Rows[index].Cells[0];
            libraryGridView.Rows[index].Selected = true;
        }
        else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.OemQuestion)
        {
            var helpMsg = """
            tTunes - Simple Tracker File Player!
            ------------------------------------
            Version: Eggshell

            by FoxCouncil 🦊
            https://github.com/FoxCouncil/tTunes
            License: MIT
            
            Keyboard Shortcuts:
            -------------------
            ESCAPE: Stop
            ENTER: Play
            SPACE: Pause
            UP/DN: Grid Up/Down
            LF/RT: Skip Back/Fwd
            PgDN/UP: Page Up/Down
            PERIOD: Next Track
            COMMA: Prev Track
            LETTERS: Goto First Letter
            F1/?: [THIS HELP DIALOG]
            """;

            MessageBox.Show(helpMsg, "tTunes Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void NextTrack()
    {
        var currentIndex = currentSelectedIndex; // libraryGridView.CurrentRow.Index;

        if (currentIndex + 1 < libraryGridView.Rows.Count)
        {
            currentIndex += 1;
        }
        else
        {
            currentIndex = 0;
        }

        libraryGridView.CurrentCell = libraryGridView.Rows[currentIndex].Cells[0];
        libraryGridView.Rows[currentIndex].Selected = true;

        LibraryPlaySelection();
    }

    private void PreviousTrack()
    {
        var currentIndex = currentSelectedIndex; // libraryGridView.CurrentRow.Index;

        if (currentIndex - 1 >= 0)
        {
            currentIndex -= 1;
        }
        else
        {
            currentIndex = libraryGridView.Rows.Count - 1;
        }

        libraryGridView.CurrentCell = libraryGridView.Rows[currentIndex].Cells[0];
        libraryGridView.Rows[currentIndex].Selected = true;

        LibraryPlaySelection();
    }

    private void LibraryPlaySelection(bool forcePlay = false)
    {
        if (currentSelectedIndex == libraryGridView.SelectedRows[0].Index)
        {
            return;
        }

        if (currentSelectedIndex >= 0)
        {
            for (int i = 0; i < libraryGridView.ColumnCount; i++)
            {
                libraryGridView[i, currentSelectedIndex].Style.BackColor = oldColor;
            }
        }

        if (libraryGridView.SelectedRows[0].DataBoundItem is not TrackerFile trackerFile)
        {
            MessageBox.Show("Something went wrong");

            return;
        }

        currentSelectedIndex = libraryGridView.SelectedRows[0].Index;

        config.Settings.SelectionIndex = currentSelectedIndex;
        config.Save();

        oldColor = libraryGridView[0, currentSelectedIndex].Style.BackColor;

        for (int i = 0; i < libraryGridView.ColumnCount; i++)
        {
            libraryGridView[i, currentSelectedIndex].Style.BackColor = Color.DarkBlue;
        }

        ThreadPool.QueueUserWorkItem(_ => 
        {
            if (!isPlaying && !forcePlay)
            {
                Player.Play(new Media(trackerFile.Path));
                Player.Stop();
            }
            else
            {
                Player.Play(new Media(trackerFile.Path));
            }
        });
    }

    private void LoadTrackerLibrary(string path)
    {
        if (libraryDataSource.DataSource != null)
        {
            libraryDataSource.Clear();
            libraryDataSource.DataSource = null;
        }

        var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(FilterForTrackerFiles).Select(file => new TrackerFile(file)).ToList();

        libraryDataSource.DataSource = files;

        Text = $"{playerName} - {path} - {files.Count:n0} Tracker File(s)";

        if (!files.Any())
        {
            return;
        }

        libraryGridView.Columns[1].Width = 420;
        libraryGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        libraryGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        libraryGridView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        libraryGridView.Columns[2].Width = 50;
        libraryGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        libraryGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        libraryGridView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        libraryGridView.Columns[3].Width = 50;
        libraryGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        libraryGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        libraryGridView.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        libraryGridView.Columns[4].Width = 50;
        libraryGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        libraryGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        libraryGridView.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        oldColor = libraryGridView[0, 0].Style.BackColor;

        libraryGridView[0, config.Settings.SelectionIndex].Selected = true;

        iconButtonPlay.Enabled = true;
        iconButtonPreviousTrack.Enabled = true;
        iconButtonNextTrack.Enabled = true;
    }

    private bool FilterForTrackerFiles(string file)
    {
        var fileInfo = new FileInfo(file);

        var extension = fileInfo.Extension.ToUpper();

        var compatible = allowListedExtensions.Contains(extension);

        return compatible;
    }

    private int GetThumbLeftPosition(TrackBar trackBar, int thumbWidth)
    {
        double min = trackBar.Minimum;
        double max = trackBar.Maximum;
        double val = trackBar.Value;

        int trackBarWidth = trackBar.ClientSize.Width - thumbWidth;
        double perc = (val - min) / (max - min);
        return (int)(perc * trackBarWidth);
    }

    private int GetThumbWidth(TrackBar trackBar)
    {
        // This is a heuristic. For more precise results, custom drawing might be necessary
        // or more sophisticated methods to get the size of the thumb.
        return (int)(trackBar.Size.Height * 0.6);
    }
}

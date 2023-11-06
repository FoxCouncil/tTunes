using LibVLCSharp;
using System.ComponentModel;
using System.Windows.Forms;
using tTunes.Models;

namespace tTunes
{
    public partial class MainForm : Form
    {
        static MediaPlayer Player => tTunes.Player;

        int currentSelectedIndex;
        Color oldColor;

        public MainForm()
        {
            InitializeComponent();

            libraryGridView.DataSource = libraryDataSource;

            iconButtonPlay.Enabled = false;
            iconButtonPause.Enabled = false;
            iconButtonStop.Enabled = false;

            iconButtonPlay.Click += (s, e) => ThreadPool.QueueUserWorkItem(_ => Player.Play());
            iconButtonPause.Click += (s, e) => ThreadPool.QueueUserWorkItem(_ => Player.Pause());
            iconButtonStop.Click += (s, e) => ThreadPool.QueueUserWorkItem(_ => Player.Stop());

            libraryGridView.MouseDoubleClick += (s, e) => LibraryPlaySelection();
            libraryGridView.KeyDown += (s, e) => HandleKeyboard(e);

            KeyDown += (s, e) => HandleKeyboard(e);

            Player.MediaChanged += (s, e) => InvokeIfRequired(() =>
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
            Player.Playing += (s, e) => InvokeIfRequired(() =>
            {
                labelPlaybackStatusText.Text = "PLAYING";

                iconButtonPlay.Enabled = false;
                iconButtonPause.Enabled = true;
                iconButtonStop.Enabled = true;

                trackBarTime.Value = 0;
            });
            Player.TimeChanged += (s, e) => InvokeIfRequired(() =>
            {
                labelTimeCurrent.Text = TimeSpan.FromMilliseconds(e.Time).ToString("mm\\:ss");
                trackBarTime.Value = (int)Math.Clamp(e.Time, 0, trackBarTime.Maximum);
            });
            Player.Stopped += (s, e) => InvokeIfRequired(() =>
            {
                labelPlaybackStatusText.Text = "STOPPED";

                labelTimeCurrent.Text = "00:00";

                iconButtonPlay.Enabled = true;
                iconButtonPause.Enabled = false;
                iconButtonStop.Enabled = false;

                trackBarTime.Value = 0;
            });
            Player.Paused += (s, e) => InvokeIfRequired(() =>
            {
                labelPlaybackStatusText.Text = "PAUSED";

                iconButtonPlay.Enabled = true;
                iconButtonPause.Enabled = false;
                iconButtonStop.Enabled = true;
            });
            
            // TODO: Change later
            Shown += (s, e) => LoadTrackerLibrary("d:\\mods");
        }

        private void HandleKeyboard(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LibraryPlaySelection();

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
        }

        private void LibraryPlaySelection()
        {
            if (currentSelectedIndex == libraryGridView.SelectedRows[0].Index)
            {
                return;
            }

            for (int i = 0; i < libraryGridView.ColumnCount; i++)
            {
                libraryGridView[i, currentSelectedIndex].Style.BackColor = oldColor;
            }

            if (libraryGridView.SelectedRows[0].DataBoundItem is not TrackerFile trackerFile)
            {
                MessageBox.Show("Something went wrong");

                return;
            }

            currentSelectedIndex = libraryGridView.SelectedRows[0].Index;

            oldColor = libraryGridView[0, currentSelectedIndex].Style.BackColor;

            for (int i = 0; i < libraryGridView.ColumnCount; i++)
            {
                libraryGridView[i, currentSelectedIndex].Style.BackColor = Color.DarkBlue;
            }

            ThreadPool.QueueUserWorkItem(_ => Player.Play(new Media(trackerFile.Path)));
        }

        private void LoadTrackerLibrary(string path)
        {
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Select(file => new TrackerFile(file));

            libraryDataSource.DataSource = files;

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
        }

        private void InvokeIfRequired(Action action)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                Invoke(action);
            }

            action();
        }
    }
}

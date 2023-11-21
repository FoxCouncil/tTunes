namespace tTunes
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            splitContainer = new SplitContainer();
            iconButtonReloadLibrary = new FontAwesome.Sharp.IconButton();
            iconButtonSelectDirectory = new FontAwesome.Sharp.IconButton();
            iconButtonNextTrack = new FontAwesome.Sharp.IconButton();
            iconButtonPreviousTrack = new FontAwesome.Sharp.IconButton();
            labelYear = new Label();
            labelFileType = new Label();
            labelTitle = new Label();
            labelTimeTotal = new Label();
            labelTimeCurrent = new Label();
            iconButtonPause = new FontAwesome.Sharp.IconButton();
            iconButtonStop = new FontAwesome.Sharp.IconButton();
            iconButtonPlay = new FontAwesome.Sharp.IconButton();
            labelPlaybackStatusText = new Label();
            trackBarTime = new TrackBar();
            libraryGridView = new DataGridView();
            libraryDataSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)libraryGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)libraryDataSource).BeginInit();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(iconButtonReloadLibrary);
            splitContainer.Panel1.Controls.Add(iconButtonSelectDirectory);
            splitContainer.Panel1.Controls.Add(iconButtonNextTrack);
            splitContainer.Panel1.Controls.Add(iconButtonPreviousTrack);
            splitContainer.Panel1.Controls.Add(labelYear);
            splitContainer.Panel1.Controls.Add(labelFileType);
            splitContainer.Panel1.Controls.Add(labelTitle);
            splitContainer.Panel1.Controls.Add(labelTimeTotal);
            splitContainer.Panel1.Controls.Add(labelTimeCurrent);
            splitContainer.Panel1.Controls.Add(iconButtonPause);
            splitContainer.Panel1.Controls.Add(iconButtonStop);
            splitContainer.Panel1.Controls.Add(iconButtonPlay);
            splitContainer.Panel1.Controls.Add(labelPlaybackStatusText);
            splitContainer.Panel1.Controls.Add(trackBarTime);
            splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(libraryGridView);
            splitContainer.Size = new Size(1146, 450);
            splitContainer.SplitterDistance = 150;
            splitContainer.TabIndex = 0;
            // 
            // iconButtonReloadLibrary
            // 
            iconButtonReloadLibrary.Anchor = AnchorStyles.Top;
            iconButtonReloadLibrary.BackColor = Color.DimGray;
            iconButtonReloadLibrary.FlatAppearance.BorderColor = Color.Black;
            iconButtonReloadLibrary.FlatStyle = FlatStyle.Popup;
            iconButtonReloadLibrary.ForeColor = Color.White;
            iconButtonReloadLibrary.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            iconButtonReloadLibrary.IconColor = Color.Gainsboro;
            iconButtonReloadLibrary.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonReloadLibrary.Location = new Point(291, 44);
            iconButtonReloadLibrary.Name = "iconButtonReloadLibrary";
            iconButtonReloadLibrary.Size = new Size(75, 55);
            iconButtonReloadLibrary.TabIndex = 15;
            iconButtonReloadLibrary.UseVisualStyleBackColor = false;
            // 
            // iconButtonSelectDirectory
            // 
            iconButtonSelectDirectory.Anchor = AnchorStyles.Top;
            iconButtonSelectDirectory.BackColor = Color.DimGray;
            iconButtonSelectDirectory.FlatAppearance.BorderColor = Color.Black;
            iconButtonSelectDirectory.FlatStyle = FlatStyle.Popup;
            iconButtonSelectDirectory.ForeColor = Color.White;
            iconButtonSelectDirectory.IconChar = FontAwesome.Sharp.IconChar.Folder;
            iconButtonSelectDirectory.IconColor = Color.Gainsboro;
            iconButtonSelectDirectory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSelectDirectory.Location = new Point(777, 43);
            iconButtonSelectDirectory.Name = "iconButtonSelectDirectory";
            iconButtonSelectDirectory.Size = new Size(75, 55);
            iconButtonSelectDirectory.TabIndex = 14;
            iconButtonSelectDirectory.UseVisualStyleBackColor = false;
            // 
            // iconButtonNextTrack
            // 
            iconButtonNextTrack.Anchor = AnchorStyles.Top;
            iconButtonNextTrack.BackColor = Color.DimGray;
            iconButtonNextTrack.FlatAppearance.BorderColor = Color.Black;
            iconButtonNextTrack.FlatStyle = FlatStyle.Popup;
            iconButtonNextTrack.ForeColor = Color.White;
            iconButtonNextTrack.IconChar = FontAwesome.Sharp.IconChar.Forward;
            iconButtonNextTrack.IconColor = Color.Gainsboro;
            iconButtonNextTrack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonNextTrack.Location = new Point(696, 43);
            iconButtonNextTrack.Name = "iconButtonNextTrack";
            iconButtonNextTrack.Size = new Size(75, 55);
            iconButtonNextTrack.TabIndex = 13;
            iconButtonNextTrack.UseVisualStyleBackColor = false;
            // 
            // iconButtonPreviousTrack
            // 
            iconButtonPreviousTrack.Anchor = AnchorStyles.Top;
            iconButtonPreviousTrack.BackColor = Color.DimGray;
            iconButtonPreviousTrack.FlatAppearance.BorderColor = Color.Black;
            iconButtonPreviousTrack.FlatStyle = FlatStyle.Popup;
            iconButtonPreviousTrack.ForeColor = Color.White;
            iconButtonPreviousTrack.IconChar = FontAwesome.Sharp.IconChar.Backward;
            iconButtonPreviousTrack.IconColor = Color.Gainsboro;
            iconButtonPreviousTrack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonPreviousTrack.Location = new Point(372, 43);
            iconButtonPreviousTrack.Name = "iconButtonPreviousTrack";
            iconButtonPreviousTrack.Size = new Size(75, 55);
            iconButtonPreviousTrack.TabIndex = 12;
            iconButtonPreviousTrack.UseVisualStyleBackColor = false;
            // 
            // labelYear
            // 
            labelYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelYear.Font = new Font("Bauhaus 93", 32F, FontStyle.Bold);
            labelYear.ForeColor = Color.FromArgb(224, 224, 224);
            labelYear.Location = new Point(980, 45);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(166, 51);
            labelYear.TabIndex = 11;
            labelYear.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelFileType
            // 
            labelFileType.Font = new Font("Bauhaus 93", 32F, FontStyle.Bold);
            labelFileType.ForeColor = Color.FromArgb(224, 224, 224);
            labelFileType.Location = new Point(0, 45);
            labelFileType.Name = "labelFileType";
            labelFileType.Size = new Size(166, 51);
            labelFileType.TabIndex = 10;
            labelFileType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTitle
            // 
            labelTitle.BackColor = Color.FromArgb(64, 64, 64);
            labelTitle.BorderStyle = BorderStyle.Fixed3D;
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Font = new Font("Consolas", 22F);
            labelTitle.ForeColor = Color.Chartreuse;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(1146, 35);
            labelTitle.TabIndex = 9;
            labelTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelTimeTotal
            // 
            labelTimeTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTimeTotal.AutoSize = true;
            labelTimeTotal.BackColor = Color.Transparent;
            labelTimeTotal.Location = new Point(1095, 132);
            labelTimeTotal.Name = "labelTimeTotal";
            labelTimeTotal.Size = new Size(48, 18);
            labelTimeTotal.TabIndex = 7;
            labelTimeTotal.Text = "00:00";
            labelTimeTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelTimeCurrent
            // 
            labelTimeCurrent.AutoSize = true;
            labelTimeCurrent.BackColor = Color.Transparent;
            labelTimeCurrent.Location = new Point(3, 132);
            labelTimeCurrent.Name = "labelTimeCurrent";
            labelTimeCurrent.Size = new Size(48, 18);
            labelTimeCurrent.TabIndex = 6;
            labelTimeCurrent.Text = "00:00";
            // 
            // iconButtonPause
            // 
            iconButtonPause.Anchor = AnchorStyles.Top;
            iconButtonPause.BackColor = Color.DimGray;
            iconButtonPause.FlatAppearance.BorderColor = Color.Black;
            iconButtonPause.FlatStyle = FlatStyle.Popup;
            iconButtonPause.ForeColor = Color.White;
            iconButtonPause.IconChar = FontAwesome.Sharp.IconChar.Pause;
            iconButtonPause.IconColor = Color.Gainsboro;
            iconButtonPause.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonPause.Location = new Point(534, 43);
            iconButtonPause.Name = "iconButtonPause";
            iconButtonPause.Size = new Size(75, 55);
            iconButtonPause.TabIndex = 4;
            iconButtonPause.UseVisualStyleBackColor = false;
            // 
            // iconButtonStop
            // 
            iconButtonStop.Anchor = AnchorStyles.Top;
            iconButtonStop.BackColor = Color.DimGray;
            iconButtonStop.FlatAppearance.BorderColor = Color.Black;
            iconButtonStop.FlatStyle = FlatStyle.Popup;
            iconButtonStop.ForeColor = Color.White;
            iconButtonStop.IconChar = FontAwesome.Sharp.IconChar.Stop;
            iconButtonStop.IconColor = Color.Gainsboro;
            iconButtonStop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonStop.Location = new Point(615, 43);
            iconButtonStop.Name = "iconButtonStop";
            iconButtonStop.Size = new Size(75, 55);
            iconButtonStop.TabIndex = 3;
            iconButtonStop.UseVisualStyleBackColor = false;
            // 
            // iconButtonPlay
            // 
            iconButtonPlay.Anchor = AnchorStyles.Top;
            iconButtonPlay.BackColor = Color.DimGray;
            iconButtonPlay.FlatAppearance.BorderColor = Color.Black;
            iconButtonPlay.FlatStyle = FlatStyle.Popup;
            iconButtonPlay.ForeColor = Color.White;
            iconButtonPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
            iconButtonPlay.IconColor = Color.Gainsboro;
            iconButtonPlay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonPlay.Location = new Point(453, 43);
            iconButtonPlay.Name = "iconButtonPlay";
            iconButtonPlay.Size = new Size(75, 55);
            iconButtonPlay.TabIndex = 2;
            iconButtonPlay.UseVisualStyleBackColor = false;
            // 
            // labelPlaybackStatusText
            // 
            labelPlaybackStatusText.Anchor = AnchorStyles.Top;
            labelPlaybackStatusText.BackColor = Color.Transparent;
            labelPlaybackStatusText.Font = new Font("Consolas", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPlaybackStatusText.ImageAlign = ContentAlignment.TopCenter;
            labelPlaybackStatusText.Location = new Point(455, 128);
            labelPlaybackStatusText.Name = "labelPlaybackStatusText";
            labelPlaybackStatusText.Size = new Size(237, 18);
            labelPlaybackStatusText.TabIndex = 1;
            labelPlaybackStatusText.Text = "STOPPED";
            labelPlaybackStatusText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBarTime
            // 
            trackBarTime.AutoSize = false;
            trackBarTime.Dock = DockStyle.Bottom;
            trackBarTime.Location = new Point(0, 105);
            trackBarTime.Name = "trackBarTime";
            trackBarTime.Size = new Size(1146, 45);
            trackBarTime.TabIndex = 8;
            trackBarTime.TickFrequency = 5;
            trackBarTime.TickStyle = TickStyle.TopLeft;
            // 
            // libraryGridView
            // 
            libraryGridView.AllowUserToAddRows = false;
            libraryGridView.AllowUserToDeleteRows = false;
            libraryGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            libraryGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            libraryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            libraryGridView.BackgroundColor = Color.Black;
            libraryGridView.BorderStyle = BorderStyle.None;
            libraryGridView.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            libraryGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Consolas", 11F);
            dataGridViewCellStyle2.ForeColor = Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionForeColor = Color.Gainsboro;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            libraryGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            libraryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Consolas", 11F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            libraryGridView.DefaultCellStyle = dataGridViewCellStyle3;
            libraryGridView.Dock = DockStyle.Fill;
            libraryGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            libraryGridView.EnableHeadersVisualStyles = false;
            libraryGridView.GridColor = Color.Red;
            libraryGridView.Location = new Point(0, 0);
            libraryGridView.MultiSelect = false;
            libraryGridView.Name = "libraryGridView";
            libraryGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Consolas", 11F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            libraryGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            libraryGridView.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = Color.Black;
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 192, 0);
            libraryGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            libraryGridView.ScrollBars = ScrollBars.Vertical;
            libraryGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            libraryGridView.ShowCellErrors = false;
            libraryGridView.ShowCellToolTips = false;
            libraryGridView.ShowEditingIcon = false;
            libraryGridView.ShowRowErrors = false;
            libraryGridView.Size = new Size(1146, 296);
            libraryGridView.TabIndex = 0;
            libraryGridView.VirtualMode = true;
            // 
            // libraryDataSource
            // 
            libraryDataSource.AllowNew = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1146, 450);
            Controls.Add(splitContainer);
            DoubleBuffered = true;
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(850, 200);
            Name = "MainForm";
            Text = "tTunes";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBarTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)libraryGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)libraryDataSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer;
        private DataGridView libraryGridView;
        private BindingSource libraryDataSource;
        private Label labelPlaybackStatusText;
        private FontAwesome.Sharp.IconButton iconButtonPlay;
        private FontAwesome.Sharp.IconButton iconButtonStop;
        private FontAwesome.Sharp.IconButton iconButtonPause;
        private Label labelTimeTotal;
        private Label labelTimeCurrent;
        private TrackBar trackBarTime;
        private Label labelTitle;
        private Label labelYear;
        private Label labelFileType;
        private FontAwesome.Sharp.IconButton iconButtonPreviousTrack;
        private FontAwesome.Sharp.IconButton iconButtonNextTrack;
        private FontAwesome.Sharp.IconButton iconButtonReloadLibrary;
        private FontAwesome.Sharp.IconButton iconButtonSelectDirectory;
    }
}

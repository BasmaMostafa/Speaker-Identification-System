
namespace Recorder.GUI
{
    partial class RecordNewUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordNewUser));
            this.lbPosition = new System.Windows.Forms.Label();
            this.chart = new Accord.Controls.Wavechart();
            this.lbLength = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.RecordAudio = new System.Windows.Forms.Button();
            this.SaveAudio = new System.Windows.Forms.Button();
            this.StopRecording = new System.Windows.Forms.Button();
            this.PlayAudio = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPosition
            // 
            this.lbPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbPosition.Location = new System.Drawing.Point(12, 30);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(72, 41);
            this.lbPosition.TabIndex = 9;
            this.lbPosition.Text = "Position: 00.00 sec.";
            this.lbPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Black;
            this.chart.ForeColor = System.Drawing.Color.DarkGreen;
            this.chart.Location = new System.Drawing.Point(90, 30);
            this.chart.Name = "chart";
            this.chart.RangeX = ((AForge.DoubleRange)(resources.GetObject("chart.RangeX")));
            this.chart.RangeY = ((AForge.DoubleRange)(resources.GetObject("chart.RangeY")));
            this.chart.SimpleMode = false;
            this.chart.Size = new System.Drawing.Size(249, 41);
            this.chart.TabIndex = 9;
            this.chart.Text = "chart1";
            // 
            // lbLength
            // 
            this.lbLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbLength.Location = new System.Drawing.Point(345, 30);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(72, 41);
            this.lbLength.TabIndex = 11;
            this.lbLength.Text = "Length: 00.00 sec.";
            this.lbLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.trackBar1.Location = new System.Drawing.Point(12, 91);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(405, 45);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // RecordAudio
            // 
            this.RecordAudio.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.RecordAudio.Location = new System.Drawing.Point(342, 118);
            this.RecordAudio.Name = "RecordAudio";
            this.RecordAudio.Size = new System.Drawing.Size(75, 35);
            this.RecordAudio.TabIndex = 12;
            this.RecordAudio.Text = "=";
            this.RecordAudio.UseVisualStyleBackColor = true;
            this.RecordAudio.Click += new System.EventHandler(this.RecordAudio_Click);
            // 
            // SaveAudio
            // 
            this.SaveAudio.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.SaveAudio.Location = new System.Drawing.Point(12, 118);
            this.SaveAudio.Name = "SaveAudio";
            this.SaveAudio.Size = new System.Drawing.Size(75, 35);
            this.SaveAudio.TabIndex = 13;
            this.SaveAudio.Text = "1";
            this.SaveAudio.UseVisualStyleBackColor = true;
            this.SaveAudio.Click += new System.EventHandler(this.SaveAudio_Click);
            // 
            // StopRecording
            // 
            this.StopRecording.AccessibleDescription = "";
            this.StopRecording.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.StopRecording.Location = new System.Drawing.Point(233, 118);
            this.StopRecording.Name = "StopRecording";
            this.StopRecording.Size = new System.Drawing.Size(75, 35);
            this.StopRecording.TabIndex = 14;
            this.StopRecording.Tag = "";
            this.StopRecording.Text = "<";
            this.StopRecording.UseVisualStyleBackColor = true;
            this.StopRecording.Click += new System.EventHandler(this.StopRecording_Click);
            // 
            // PlayAudio
            // 
            this.PlayAudio.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.PlayAudio.Location = new System.Drawing.Point(120, 118);
            this.PlayAudio.Name = "PlayAudio";
            this.PlayAudio.Size = new System.Drawing.Size(75, 35);
            this.PlayAudio.TabIndex = 15;
            this.PlayAudio.Text = "4";
            this.PlayAudio.UseVisualStyleBackColor = true;
            this.PlayAudio.Click += new System.EventHandler(this.PlayAudio_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "wav";
            this.saveFileDialog1.FileName = "file.wav";
            this.saveFileDialog1.Filter = "Wave files|*.wav|All files|*.*";
            this.saveFileDialog1.Title = "Save wave file";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(438, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // RecordNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 165);
            this.Controls.Add(this.PlayAudio);
            this.Controls.Add(this.StopRecording);
            this.Controls.Add(this.SaveAudio);
            this.Controls.Add(this.RecordAudio);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.lbPosition);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RecordNewUser";
            this.Text = "Record New User";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPosition;
        private Accord.Controls.Wavechart chart;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button RecordAudio;
        private System.Windows.Forms.Button SaveAudio;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button StopRecording;
        private System.Windows.Forms.Button PlayAudio;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;

    }
}
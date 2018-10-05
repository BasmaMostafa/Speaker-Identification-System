namespace Recorder.GUI
{
    partial class VoiceTest
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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceTest));
               this.lbPosition = new System.Windows.Forms.Label();
               this.TestWaveChart = new Accord.Controls.Wavechart();
               this.lbLength = new System.Windows.Forms.Label();
               this.trackBar1 = new System.Windows.Forms.TrackBar();
               this.RecordTestAudio = new System.Windows.Forms.Button();
               this.StopRecordingTest = new System.Windows.Forms.Button();
               this.PlayTestAudio = new System.Windows.Forms.Button();
               this.timer1 = new System.Windows.Forms.Timer(this.components);
               this.TestAudio = new System.Windows.Forms.Button();
               this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
               this.menuStrip1 = new System.Windows.Forms.MenuStrip();
               this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
               this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
               ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
               this.menuStrip1.SuspendLayout();
               this.SuspendLayout();
               // 
               // lbPosition
               // 
               this.lbPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
               this.lbPosition.Location = new System.Drawing.Point(12, 24);
               this.lbPosition.Name = "lbPosition";
               this.lbPosition.Size = new System.Drawing.Size(72, 41);
               this.lbPosition.TabIndex = 9;
               this.lbPosition.Text = "Position: 00.00 sec.";
               this.lbPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // TestWaveChart
               // 
               this.TestWaveChart.BackColor = System.Drawing.Color.Black;
               this.TestWaveChart.ForeColor = System.Drawing.Color.DarkBlue;
               this.TestWaveChart.Location = new System.Drawing.Point(90, 24);
               this.TestWaveChart.Name = "TestWaveChart";
               this.TestWaveChart.RangeX = ((AForge.DoubleRange)(resources.GetObject("TestWaveChart.RangeX")));
               this.TestWaveChart.RangeY = ((AForge.DoubleRange)(resources.GetObject("TestWaveChart.RangeY")));
               this.TestWaveChart.SimpleMode = false;
               this.TestWaveChart.Size = new System.Drawing.Size(249, 41);
               this.TestWaveChart.TabIndex = 10;
               this.TestWaveChart.Text = "chart1";
               // 
               // lbLength
               // 
               this.lbLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
               this.lbLength.Location = new System.Drawing.Point(345, 24);
               this.lbLength.Name = "lbLength";
               this.lbLength.Size = new System.Drawing.Size(72, 41);
               this.lbLength.TabIndex = 11;
               this.lbLength.Text = "Length: 00.00 sec.";
               this.lbLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // trackBar1
               // 
               this.trackBar1.Location = new System.Drawing.Point(12, 85);
               this.trackBar1.Name = "trackBar1";
               this.trackBar1.Size = new System.Drawing.Size(405, 45);
               this.trackBar1.TabIndex = 12;
               this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
               // 
               // RecordTestAudio
               // 
               this.RecordTestAudio.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
               this.RecordTestAudio.ForeColor = System.Drawing.Color.Black;
               this.RecordTestAudio.Location = new System.Drawing.Point(345, 111);
               this.RecordTestAudio.Name = "RecordTestAudio";
               this.RecordTestAudio.Size = new System.Drawing.Size(72, 34);
               this.RecordTestAudio.TabIndex = 13;
               this.RecordTestAudio.Text = "=";
               this.RecordTestAudio.UseVisualStyleBackColor = true;
               this.RecordTestAudio.Click += new System.EventHandler(this.RecordTestAudio_Click);
               // 
               // StopRecordingTest
               // 
               this.StopRecordingTest.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
               this.StopRecordingTest.ForeColor = System.Drawing.Color.Black;
               this.StopRecordingTest.Location = new System.Drawing.Point(231, 111);
               this.StopRecordingTest.Name = "StopRecordingTest";
               this.StopRecordingTest.Size = new System.Drawing.Size(76, 34);
               this.StopRecordingTest.TabIndex = 15;
               this.StopRecordingTest.Text = "<";
               this.StopRecordingTest.UseVisualStyleBackColor = true;
               this.StopRecordingTest.Click += new System.EventHandler(this.StopRecordingTest_Click);
               // 
               // PlayTestAudio
               // 
               this.PlayTestAudio.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
               this.PlayTestAudio.ForeColor = System.Drawing.Color.Black;
               this.PlayTestAudio.Location = new System.Drawing.Point(132, 111);
               this.PlayTestAudio.Name = "PlayTestAudio";
               this.PlayTestAudio.Size = new System.Drawing.Size(66, 34);
               this.PlayTestAudio.TabIndex = 16;
               this.PlayTestAudio.Text = "4";
               this.PlayTestAudio.UseVisualStyleBackColor = true;
               this.PlayTestAudio.Click += new System.EventHandler(this.PlayTestAudio_Click);
               // 
               // timer1
               // 
               this.timer1.Enabled = true;
               this.timer1.Tick += new System.EventHandler(this.updateTimer_Tick);
               // 
               // TestAudio
               // 
               this.TestAudio.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
               this.TestAudio.Location = new System.Drawing.Point(28, 111);
               this.TestAudio.Name = "TestAudio";
               this.TestAudio.Size = new System.Drawing.Size(69, 34);
               this.TestAudio.TabIndex = 17;
               this.TestAudio.Text = "a";
               this.TestAudio.UseVisualStyleBackColor = true;
               this.TestAudio.Click += new System.EventHandler(this.TestAudio_Click);
               // 
               // saveFileDialog1
               // 
               this.saveFileDialog1.DefaultExt = "wav";
               this.saveFileDialog1.FileName = "file.wav";
               this.saveFileDialog1.Filter = "Wave files|*.wav|All files|*.*";
               this.saveFileDialog1.Title = "Save wave file";
               this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
               // 
               // menuStrip1
               // 
               this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
               this.menuStrip1.Location = new System.Drawing.Point(0, 0);
               this.menuStrip1.Name = "menuStrip1";
               this.menuStrip1.Size = new System.Drawing.Size(451, 24);
               this.menuStrip1.TabIndex = 18;
               this.menuStrip1.Text = "menuStrip1";
               // 
               // toolStripMenuItem1
               // 
               this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
               this.toolStripMenuItem1.Name = "toolStripMenuItem1";
               this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
               this.toolStripMenuItem1.Text = "File";
               // 
               // fileToolStripMenuItem
               // 
               this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
               this.fileToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
               this.fileToolStripMenuItem.Text = "Open";
               this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
               // 
               // openFileDialog1
               // 
               this.openFileDialog1.FileName = "openFileDialog1";
               // 
               // VoiceTest
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(451, 157);
               this.Controls.Add(this.TestAudio);
               this.Controls.Add(this.PlayTestAudio);
               this.Controls.Add(this.StopRecordingTest);
               this.Controls.Add(this.RecordTestAudio);
               this.Controls.Add(this.trackBar1);
               this.Controls.Add(this.lbLength);
               this.Controls.Add(this.TestWaveChart);
               this.Controls.Add(this.lbPosition);
               this.Controls.Add(this.menuStrip1);
               this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
               this.MainMenuStrip = this.menuStrip1;
               this.Name = "VoiceTest";
               this.Text = "TestVoice";
              
               ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
               this.menuStrip1.ResumeLayout(false);
               this.menuStrip1.PerformLayout();
               this.ResumeLayout(false);
               this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPosition;
        private Accord.Controls.Wavechart TestWaveChart;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button RecordTestAudio;
        private System.Windows.Forms.Button StopRecordingTest;
        private System.Windows.Forms.Button PlayTestAudio;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button TestAudio;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
namespace Recorder.GUI
{
     partial class choose
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
               if (disposing && (components != null))
               {
                    components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(choose));
            this.AddVoice = new System.Windows.Forms.Button();
            this.TestVoicebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CloseSystem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddVoice
            // 
            this.AddVoice.Location = new System.Drawing.Point(120, 80);
            this.AddVoice.Name = "AddVoice";
            this.AddVoice.Size = new System.Drawing.Size(138, 23);
            this.AddVoice.TabIndex = 0;
            this.AddVoice.Text = "Add User";
            this.AddVoice.UseVisualStyleBackColor = true;
            this.AddVoice.Click += new System.EventHandler(this.AddVoice_Click);
            // 
            // TestVoicebtn
            // 
            this.TestVoicebtn.Location = new System.Drawing.Point(120, 130);
            this.TestVoicebtn.Name = "TestVoicebtn";
            this.TestVoicebtn.Size = new System.Drawing.Size(138, 23);
            this.TestVoicebtn.TabIndex = 1;
            this.TestVoicebtn.Text = "Test Voice";
            this.TestVoicebtn.UseVisualStyleBackColor = true;
            this.TestVoicebtn.Click += new System.EventHandler(this.TestVoicebtn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "             Welcome To Speaker Identification System                  ";
            // 
            // CloseSystem
            // 
            this.CloseSystem.Location = new System.Drawing.Point(120, 179);
            this.CloseSystem.Name = "CloseSystem";
            this.CloseSystem.Size = new System.Drawing.Size(138, 23);
            this.CloseSystem.TabIndex = 3;
            this.CloseSystem.Text = "Close System";
            this.CloseSystem.UseVisualStyleBackColor = true;
            this.CloseSystem.Click += new System.EventHandler(this.CloseSystem_Click);
            // 
            // choose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 261);
            this.Controls.Add(this.CloseSystem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TestVoicebtn);
            this.Controls.Add(this.AddVoice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "choose";
            this.Text = "Speaker Identification System";
            this.Load += new System.EventHandler(this.choose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Button AddVoice;
          private System.Windows.Forms.Button TestVoicebtn;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.Button CloseSystem;
     }
}
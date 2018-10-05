using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Recorder.GUI
{
     public partial class choose : Form
     {
         //Initialize Data
         private name NameForm = new name();
         

         //Form Constructor
          public choose()
          {
               InitializeComponent();
          }
         //Add new voice to the database

          private void AddVoice_Click(object sender, EventArgs e)
          {
              NameForm.Show();
               this.Hide();
          }
         //Form Loader

          private void choose_Load(object sender, EventArgs e)
          {

          }
         //Test a voice

          private void TestVoicebtn_Click(object sender, EventArgs e)
          {
              VoiceTest TestVoiceForm = new VoiceTest();
              TestVoiceForm.Show();
               this.Hide();
          }

          private void CloseSystem_Click(object sender, EventArgs e)
          {
              Close();
          }

         
     }
}

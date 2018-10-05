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
     public partial class name : Form
     {
         //Data Declaration
         RecordNewUser RecordNewUserForm ;

         //Form Constructor
          public name()
          {
               InitializeComponent();
          }
         //Recording Voice

          private void StartRecording_Click(object sender, EventArgs e)
          {
               
               string UserName = name_textBox.Text.ToString();
               RecordNewUserForm = new RecordNewUser(UserName);
               RecordNewUserForm.Show();
               this.Hide();
          }

     }
}

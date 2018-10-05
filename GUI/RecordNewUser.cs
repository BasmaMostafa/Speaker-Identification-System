using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Accord.Audio;
using Accord.Audio.Formats;
using Accord.DirectSound;
using Accord.Audio.Filters;
using Recorder.Recorder;
using Recorder.MFCC;




namespace Recorder.GUI
{
    public partial class RecordNewUser : Form
    {



        // Data Declaration
        private string path;
        private AudioSignal signal = new AudioSignal();
        private Encoder encoder;
        private Decoder decoder;
        public string UserName = "";
        private bool isRecorded;
        private choose StartUpForm = new choose();
       
        //Class Constructors
        public RecordNewUser()
        {
            InitializeComponent();
        }

         public RecordNewUser(string name)
        {
            InitializeComponent();
            UserName = name;

            // Configure the wavechart
            chart.SimpleMode = true;
            chart.AddWaveform("wave", Color.Maroon, 1, false);
            updateButtons();
        }


        //============================================================================================================================//

        /// <summary>
        ///   This callback will be called when there is some error with the audio 
        ///   source. It can be used to route exceptions so they don't compromise 
        ///   the audio processing pipeline.
        /// </summary>
        /// 
        private void source_AudioSourceError(object sender, AudioSourceErrorEventArgs e)
        {
            throw new Exception(e.Description);
        }

       //=============================================================================================================================//

        /// <summary>
        ///   Updates the audio display in the wave chart
        /// </summary>
        /// 
        private void updateWaveform(float[] samples, int length)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    chart.UpdateWaveform("wave", samples, length);
                }));
            }
            else
            {
                if (this.encoder != null) { chart.UpdateWaveform("wave", this.encoder.current, length); }
            }
        }



       //==========================================================================================================================//
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (this.encoder != null) { lbLength.Text = String.Format("Length: {0:00.00} sec.", this.encoder.duration / 1000.0); }
        }

        //======================================================================================================================//

        /// <summary>
        ///   This method will be called whenever there is a new input audio frame 
        ///   to be processed. This would be the case for samples arriving at the 
        ///   computer's microphone
        /// </summary>
        /// 
        private void source_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.encoder.addNewFrame(eventArgs.Signal);
            updateWaveform(this.encoder.current, eventArgs.Signal.Length);
        }

        //======================================================================================================================//

        private void RecordAudio_Click(object sender, EventArgs e)
        {
            isRecorded = true;
            this.encoder = new Encoder(source_NewFrame, source_AudioSourceError);
            this.encoder.Start();

            updateButtons();
        }


        //=========================================================================================================================//

        private void updateButtons()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(updateButtons));
                return;
            }

            if (this.encoder != null && this.encoder.IsRunning())
            {
               //need update
                RecordAudio.Enabled = false;
                PlayAudio.Enabled = false;
                trackBar1.Enabled = false;
            }

            else if (this.decoder != null && this.decoder.IsRunning())
            {
               //need update
                RecordAudio.Enabled = false;
                PlayAudio.Enabled = false;
                trackBar1.Enabled = true;
            }

            else
            {
                //need update
                RecordAudio.Enabled = true;
                trackBar1.Enabled = this.decoder != null;
                PlayAudio.Enabled = this.path != null || this.encoder != null;//stream != null;
                trackBar1.Value = 0;
            }
        }
//===========================================================================================================================================//
        private void SaveAudio_Click(object sender, EventArgs e)
        {
            //Save the signal in a wave file
            saveFileDialog1.ShowDialog(this);
            string name = saveFileDialog1.FileName;
            

            //Extract the Features for saving 
            signal = AudioOperations.OpenAudioFile(name);
            Sequence S = AudioOperations.ExtractFeatures(signal);

            //Write the Sequence in file
            RWFile Write = new RWFile();
            Write.WriteInFile(S, UserName);

            MessageBox.Show("Voice Recorded Successfully");

            //Re-direct the user to the start up form
            StartUpForm.Show();

            //hide the current form
            this.Hide();

        }
//============================================================================================================================================//

        private void Stop()
        {
            if (this.encoder != null) { this.encoder.Stop(); }
            if (this.decoder != null) { this.decoder.Stop(); }
        }
//============================================================================================================================================//
        private void StopRecording_Click(object sender, EventArgs e)
        {
            Stop();
            updateButtons();
            updateWaveform(new float[BaseRecorder.FRAME_SIZE], BaseRecorder.FRAME_SIZE);
        }

//===============================================================================================================================================//
      
        void output_AudioOutputError(object sender, AudioOutputErrorEventArgs e)
        {
            throw new Exception(e.Description);
        }
  //========================================================================================================================================//

        private void InitializeDecoder()
        {
            if (isRecorded)
            {
                // First, we rewind the stream
                this.encoder.stream.Seek(0, SeekOrigin.Begin);
                this.decoder = new Decoder(this.encoder.stream, this.Handle, output_AudioOutputError, output_FramePlayingStarted, output_NewFrameRequested, output_PlayingFinished);
            }
            else
            {
                this.decoder = new Decoder(this.path, this.Handle, output_AudioOutputError, output_FramePlayingStarted, output_NewFrameRequested, output_PlayingFinished);
            }
        }

        //========================================================================================================================================//
        /// <summary>
        ///   This event will be triggered as soon as the audio starts playing in the 
        ///   computer speakers. It can be used to update the UI and to notify that soon
        ///   we will be requesting additional frames.
        /// </summary>
        /// 
        private void output_FramePlayingStarted(object sender, PlayFrameEventArgs e)
        {
            updateTrackbar(e.FrameIndex);

            if (e.FrameIndex + e.Count < this.decoder.frames)
            {
                int previous = this.decoder.Position;
                decoder.Seek(e.FrameIndex);

                Signal s = this.decoder.Decode(e.Count);
                decoder.Seek(previous);

                updateWaveform(s.ToFloat(), s.Length);
            }
        }

        //========================================================================================================================================//
        /// <summary>
        ///   This event is triggered when the sound card needs more samples to be
        ///   played. When this happens, we have to feed it additional frames so it
        ///   can continue playing.
        /// </summary>
        /// 
        private void output_NewFrameRequested(object sender, NewFrameRequestedEventArgs e)
        {
            this.decoder.FillNewFrame(e);
        }
        //========================================================================================================================================//

        /// <summary>
        ///   This event will be triggered when the output device finishes
        ///   playing the audio stream. Again we can use it to update the UI.
        /// </summary>
        /// 
        private void output_PlayingFinished(object sender, EventArgs e)
        {
            updateButtons();
            updateWaveform(new float[BaseRecorder.FRAME_SIZE], BaseRecorder.FRAME_SIZE);
        }

        /// <summary>
        ///   Updates the current position at the trackbar.
        /// </summary>
        /// 
        private void updateTrackbar(int value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    trackBar1.Value = Math.Max(trackBar1.Minimum, Math.Min(trackBar1.Maximum, value));
                }));
            }
            else
            {
                trackBar1.Value = Math.Max(trackBar1.Minimum, Math.Min(trackBar1.Maximum, value));
            }
        }

        //========================================================================================================================================//

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.encoder != null)
            {

                Stream fileStream = saveFileDialog1.OpenFile();
                this.encoder.Save(fileStream);
            }
        }

        private void PlayAudio_Click(object sender, EventArgs e)
        {
            InitializeDecoder();
            // Configure the track bar so the cursor
            // can show the proper current position
            if (trackBar1.Value < this.decoder.frames)
                this.decoder.Seek(trackBar1.Value);
            trackBar1.Maximum = this.decoder.samples;
            this.decoder.Start();
            updateButtons();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                isRecorded = false;
                path = open.FileName;
                //Open the selected audio file
                signal = AudioOperations.OpenAudioFile(path);

                Sequence seq = AudioOperations.ExtractFeatures(signal);
                updateButtons();
            }
        }


    }
}

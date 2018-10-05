using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Accord.Audio;
using Accord.Audio.Formats;
using Accord.DirectSound;
using Accord.Audio.Filters;
using Recorder.Recorder;
using Recorder.MFCC;
namespace Recorder.GUI
{
    public partial class VoiceTest : Form
    {
        //Data Declartion

        private string path;
        private AudioSignal signal = new AudioSignal();
        private Encoder encoder;
        private Decoder decoder;
        private bool isRecorded;
        private choose StartUpForm = new choose();
        private RWFile ReadVoices;
        private DynamicTimeWarping DTW = new DynamicTimeWarping();
        private  int K ;
        public VoiceTest()
        {
            InitializeComponent();

            // Configure the wavechart
            TestWaveChart.SimpleMode = true;
            TestWaveChart.AddWaveform("wave", Color.Maroon, 1, false);
            updateButtons();
        }



        //============================================================================================================================//

        //Given
        private void source_AudioSourceError(object sender, AudioSourceErrorEventArgs e)
        {
            throw new Exception(e.Description);
        }

        //=============================================================================================================================//

        //Given
        private void updateWaveform(float[] samples, int length)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    TestWaveChart.UpdateWaveform("wave", samples, length);
                }));
            }
            else
            {
                if (this.encoder != null) { TestWaveChart.UpdateWaveform("wave", this.encoder.current, length); }
            }
        }


        //==========================================================================================================================//
        //Given
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (this.encoder != null) { lbLength.Text = String.Format("Length: {0:00.00} sec.", this.encoder.duration / 1000.0); }
        }

        //======================================================================================================================//

        //Given
        private void source_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.encoder.addNewFrame(eventArgs.Signal);
            updateWaveform(this.encoder.current, eventArgs.Signal.Length);
        }

        //======================================================================================================================//

        //Given
        private void Stop()
        {
            if (this.encoder != null) { this.encoder.Stop(); }
            if (this.decoder != null) { this.decoder.Stop(); }
        }

        //=====================================================================================================================//

        //Given
        void output_AudioOutputError(object sender, AudioOutputErrorEventArgs e)
        {
            throw new Exception(e.Description);
        }
        //========================================================================================================================================//

        //Given
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

        //===========================================================================================================================================//

        //Given
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

        //===============================================================================================================================//

        //Given
        private void output_NewFrameRequested(object sender, NewFrameRequestedEventArgs e)
        {
            this.decoder.FillNewFrame(e);
        }

        //===========================================================================================================================================//

        //Given
        private void output_PlayingFinished(object sender, EventArgs e)
        {
            updateButtons();
            updateWaveform(new float[BaseRecorder.FRAME_SIZE], BaseRecorder.FRAME_SIZE);
        }
        //=======================================================================================================================================//

        //Given
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

        //Given
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
                RecordTestAudio.Enabled = false;
                PlayTestAudio.Enabled = false;
                trackBar1.Enabled = false;
            }

            else if (this.decoder != null && this.decoder.IsRunning())
            {
                //need update
                RecordTestAudio.Enabled = false;
                PlayTestAudio.Enabled = false;
                trackBar1.Enabled = true;
            }

            else
            {
                //need update
                RecordTestAudio.Enabled = true;
                trackBar1.Enabled = this.decoder != null;
                PlayTestAudio.Enabled = this.path != null || this.encoder != null;//stream != null;
                trackBar1.Value = 0;
            }
        }
        //=========================================================================================================================//

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.encoder != null)
            {

                Stream fileStream = saveFileDialog1.OpenFile();
                this.encoder.Save(fileStream);
            }
        }

        //======================================================================================================================//
        private void RecordTestAudio_Click(object sender, EventArgs e)
        {
            isRecorded = true;
            this.encoder = new Encoder(source_NewFrame, source_AudioSourceError);
            this.encoder.Start();

            updateButtons();
        }

        //==================================================================================================================================//
        private void StopRecordingTest_Click(object sender, EventArgs e)
        {
            Stop();
            updateButtons();
            updateWaveform(new float[BaseRecorder.FRAME_SIZE], BaseRecorder.FRAME_SIZE);

        }
        //==================================================================================================================================//
        private void PlayTestAudio_Click(object sender, EventArgs e)
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

        private void TestAudio_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string FilePath = saveFileDialog1.FileName;

            signal = AudioOperations.OpenAudioFile(FilePath);
            Sequence TestSequence = AudioOperations.ExtractFeatures(signal);
           
            Sequence VoiceSequence;
             
            FileStream FS = new FileStream("test2.txt", FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS);

            int NoOfVoices = (int)FS.ReadByte();
            ReadVoices = new RWFile(NoOfVoices);

            DTW.VoiceDifferences = new double[NoOfVoices];

            for (int i = 0; i < NoOfVoices; i++)
            {
                VoiceSequence = new Sequence();
                VoiceSequence = ReadVoices.ReadFromFile(FS, SR, i);
                  K = Math.Abs(TestSequence.NoOfFrames-VoiceSequence.NoOfFrames);
                DTW.VoiceDifferences[i] = DTW.Compare(TestSequence, VoiceSequence, 2);

            }
            FS.Close();
            SR.Close();



            string SpeakerName = DTW.GetSpeakerName(ReadVoices.UserNames, NoOfVoices);
            MessageBox.Show("Identified Speaker is " + SpeakerName);
         //   MessageBox.Show(SpeakerName);
            this.Hide();
            StartUpForm.Show();

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
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
            //}




            //===========================================================================================================================================//



        }

        
    }
}

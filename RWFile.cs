using Accord.Audio;
using Accord.Audio.Formats;
using Recorder.MFCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Recorder.MFCC;
namespace Recorder
{
     class RWFile
     {
         public Sequence fields;
          public Sequence test;
          public static int NumberOfVoices;
          public string[] UserNames;

         //Class Constructor
          public  RWFile ()
          {
              
          }

          public RWFile(int NoOfVoices)
          {
              UserNames = new string[NoOfVoices]; 
          }
         //====================================================================================================//
          public void update()
          {
               FileStream FS = new FileStream("test2.txt", FileMode.Open, FileAccess.ReadWrite);
               StreamWriter sw = new StreamWriter(FS);


               NumberOfVoices = (int)FS.ReadByte();
               NumberOfVoices += 1;
               sw.Flush();
               sw.BaseStream.Seek(0, SeekOrigin.Begin);
               FS.WriteByte((byte)NumberOfVoices);
               Console.WriteLine(NumberOfVoices);
               sw.WriteLine();
               sw.Close();
               Console.WriteLine("Updated");
          
               FS.Close();
          }
         //=======================================================================================================//

          public void WriteInFile(Sequence Seq, string Name)
          {
               
               FileStream FS;

               if (!(File.Exists("test2.txt")))
               {
                    FS = new FileStream("test2.txt", FileMode.Create);
                    NumberOfVoices = 0;
                    FS.WriteByte((byte) NumberOfVoices);
                    FS.Close();
               }
              

               FS = new FileStream("test2.txt", FileMode.Append,FileAccess.Write);
               StreamWriter SW=new StreamWriter(FS);
             
               
               int NoOfFrames = Seq.NoOfFrames;
               SW.WriteLine();
               SW.WriteLine(Name);
               SW.WriteLine(NoOfFrames);
               for (int i = 0; i < NoOfFrames; i++)
               {
                    for (int j = 0; j < 13; j++)
                    {
                         SW.Write(Seq.Frames[i].Features[j] );
                         SW.Write("@");
                    }
                    SW.WriteLine();
               }

               SW.Close();
               FS.Close();
               update();
               
           
               
          }

         //=================================================================================================================\\
          public void WriteTestFile(Sequence seq)
          {
               FileStream FS = new FileStream("test.txt", FileMode.Truncate);
               StreamWriter SW = new StreamWriter(FS);
               int NoOfFrames = seq.NoOfFrames;

              SW.WriteLine(NoOfFrames);

               for (int i = 0; i < NoOfFrames; i++)
               {
                    for (int j = 0; j < 13; j++)
                    {
                         SW.Write(seq.Frames[i].Features[j]);
                         SW.Write("@");
                    }
                    SW.WriteLine();
               }
               
              SW.Close();
               FS.Close();
          }

         //=================================================================================================================================//

          public Sequence ReadTestFile()
          {
               FileStream FS = new FileStream("test.txt", FileMode.Open);
               StreamReader SR = new StreamReader(FS);

               int NoOfFrames = int.Parse(SR.ReadLine());
               test = new Sequence();
               test.NoOfFrames = NoOfFrames;
               for (int i = 0; i < NoOfFrames; i++)
               {
                    string str = SR.ReadLine();
                    string[] Features = new string[13];
                    Features = str.Split('@');

                    for (int j = 0; j < 13; j++)
                    {
                         test.Frames[i].Features[j] = float.Parse(Features[j]);

                    }

               }

               SR.Close();
               FS.Close();
               return test;
          }

        
         //=====================================================================================================================================//
          public Sequence ReadFromFile(FileStream FS, StreamReader SR , int Index)
          {
              //Read Empty Line Between Voices
              SR.ReadLine();
              //Collect all user names 
               UserNames[Index] = SR.ReadLine();

               int NoOFFrames = int.Parse(SR.ReadLine());

              //Initialize Frames Sequence
               fields = new Sequence();
               fields.NoOfFrames = NoOFFrames;
               fields.Frames = new MFCC.MFCCFrame[NoOFFrames];

               for (int i = 0; i < NoOFFrames; i++)
               {
                   fields.Frames[i] = new MFCC.MFCCFrame();
               }

                   //Read Features From File
                   for (int i = 0; i < NoOFFrames; i++)
                   {
                       string str = SR.ReadLine();
                       string[] features = new string[13];
                       features = str.Split('@');
                       for (int j = 0; j < 13; j++)
                       {
                           fields.Frames[i].Features[j] = float.Parse(features[j]);

                       }

                   }
               return fields;
          }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recorder.MFCC;

namespace Recorder
{
     class DynamicTimeWarping
     {

          //Data Declaration

          //Hold Differences between test and all voices
          public double[] VoiceDifferences;

          public DynamicTimeWarping()
          {
          }


          //Return the user name matches with the test voice
          public string GetSpeakerName(string[] UserNames, int NoOfUsers)
          {
               //Eventually Hold Mini Difference For the best voice match
               double BestMatch = double.MaxValue;
               string UserName = "";

               for (int i = 0; i < NoOfUsers; i++)
               {
                    // Console.WriteLine(VoiceDifferences[i]);

                    if (VoiceDifferences[i] < BestMatch)
                    {
                         Console.WriteLine("voicedifferencse : : ");
                         Console.WriteLine(VoiceDifferences[i]);
                         BestMatch = VoiceDifferences[i];
                         UserName = UserNames[i];

                    }
               }
               return UserName;

          }


          //Compare two sequences and Return DTW[n,m] which is mininmum diff between test and voice 
          public double Compare(Sequence Test, Sequence Voice, int Band_Width)
          {
               int N = Test.NoOfFrames;
               int M = Voice.NoOfFrames;

               if (N > M)
               {
                    int temp;
                    temp = M;
                    M = N;
                    N = temp;
               }


               double[,] DTW = new double[N + 1, M + 1];
               double Cost = 0;
               // initialization of base cases
               DTW[0, 0] = 0;

               for (int i = 1; i <= N; i++)
                    DTW[i, 0] = double.MaxValue;

               for (int j = 1; j <= M; j++)
                    DTW[0, j] = double.MaxValue;
               bool done;
               //Construct the Accumulated cost distance matrix
               for (int j = 1; j <= M; j++)
               {
                    done = false;
                    //int end = Math.Abs(((-j - Band_Width) * M) / N);
                    //int start = Math.Abs(((Band_Width - j) * M) / N);
                    ////Console.WriteLine(start);
                    ////Console.WriteLine(End);
                    int i = 1;
                    //for (int i =1 ;i <= N; i++)
                    //{
                    bool inner = false;
                    while (!done &&  i<N)
                    {
                         double r = (i * N) / M;
                         int eq = Math.Abs(  Convert.ToInt32(j - Math.Ceiling(r)));

                         if (eq <= Band_Width)
                         {
                              Console.WriteLine("i is :: " + i + "  n is =" + N + ">>>>>" + "j is :: " + j + "  M is =" + M);
                              Cost = EuclideanDistance(Test.Frames[i - 1], Voice.Frames[j - 1]);
                              Cost += Math.Min(DTW[i, j - 1], Math.Min(DTW[i - 1, j], DTW[i - 1, j - 1]));
                              DTW[i, j] = Cost;
                              inner = true;

                         }
                         else if (eq > Band_Width && inner)
                              done = true;
                         i++;
                    }
               }





               return DTW[N, M];


          }


          //Frame Comparison
          private double EuclideanDistance(MFCC.MFCCFrame vec1, MFCC.MFCCFrame vec2)
          {
               double Distance = 0.0;
               for (int K = 0; K < 13; K++)
                    Distance += (vec1.Features[K] - vec2.Features[K]) * (vec1.Features[K] - vec2.Features[K]);

               return Math.Sqrt(Distance);

          }
     }
}

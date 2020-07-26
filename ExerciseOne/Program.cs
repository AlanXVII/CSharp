using System;
using System.Threading;

namespace ExerciseOne
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public void CallStopwatch()
        {
            var sw = new MyStopWatch();
            sw.Start();
            Thread.Sleep(1000);
            sw.Stop();

            TimeSpan te = sw.Elapsed();

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", te.Hours, te.Minutes, te.Seconds, te.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        public void CallStackOverFlowPost()
        {

        }
    }
}

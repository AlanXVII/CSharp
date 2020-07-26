using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseOne
{
    class MyStopWatch
    {
        public DateTime StartTime;
        public DateTime StopTime;
        public TimeSpan TimeElapsed;

        public MyStopWatch()
        {

        }

        public void Start()
        {
            StartTime = DateTime.Now;
        }

        public void Stop()
        {
            StopTime = DateTime.Now;
        }

        public TimeSpan Elapsed()
        {
            TimeElapsed = StopTime - StartTime;
            return TimeElapsed;
        }

    }
}

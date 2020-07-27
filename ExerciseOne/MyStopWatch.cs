using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseOne
{
    class MyStopWatch
    {
        public DateTime StartTime { get; private set; }
        public DateTime StopTime { get; private set; }

        private TimeSpan _timeElapsed;
        private bool _started;
        private bool _stopped;
       
        public void Start()
        {
            if (_started == false)
            {
                StartTime = DateTime.Now;
                _started = true;
                _stopped = false;
            }
            else if (_started == true)
            {
                throw new InvalidOperationException("The Stopwatch has already been started");
            }
        }

        public void Stop()
        {
            if (_started == true & _stopped == false)
            {
                StopTime = DateTime.Now;
                _stopped = true;
                _started = false;
            }
            else if (_started == false)
            {
                throw new InvalidOperationException("The Stopwatch hasn't been started yet");
            }
            
        }

        public void Reset()
        {
            if (_stopped == true)
            {
                StopTime = DateTime.MinValue;
                StartTime = DateTime.MinValue;
            }
            else if (_stopped == false & _started == true)
            {
                throw new InvalidOperationException("The StopWatch needs to be Stopped First");
            }
        }

        public TimeSpan Elapsed()
        {
            if (_stopped == false)
            {
                throw new InvalidOperationException("The Stopwatch is still running");
            }
            else if (_stopped == true)
            {
                _timeElapsed = StopTime - StartTime;
                _stopped = false;
            }
            return _timeElapsed;
        }
    }
}

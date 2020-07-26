using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseOne
{
    class MyStopWatch
    {
        private DateTime _startTime;
        private DateTime _stopTime;
        private TimeSpan _timeElapsed;
        private bool _started;
        private bool _stopped;

        public MyStopWatch()
        {

        }
       
        public void Start()
        {
            if (_started == false)
            {
                _startTime = DateTime.Now;
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
                _stopTime = DateTime.Now;
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
                _stopTime = DateTime.MinValue;
                _startTime = DateTime.MinValue;
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
                _timeElapsed = _stopTime - _startTime;
                _stopped = false;
            }
            return _timeElapsed;
        }
    }
}

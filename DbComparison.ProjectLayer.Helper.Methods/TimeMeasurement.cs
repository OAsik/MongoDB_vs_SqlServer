using System;
using System.Diagnostics;

namespace DbComparison.ProjectLayer.Helper.Methods
{
    public class TimeMeasurement
    {
        Stopwatch sw = null;

        public TimeMeasurement()
        {
            if (sw == null)
            {
                sw = new Stopwatch();
            }
        }

        public void StartWatch()
        {
            sw.Start();
        }

        public void StopWatch()
        {
            sw.Stop();
        }

        public void ResetWatch()
        {
            sw.Stop();
        }

        public TimeSpan PrintTimeSpent()
        {
            return sw.Elapsed;
        }
    }
}
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace EggTimer
{
    public class ActivityRecord
    {
        public DateTime When;
        public long DurationInMilliseconds;
        public ActivityRecord(DateTime when)
        {
            this.When = when;
            this.DurationInMilliseconds = 0;
        }
    }
    public class ActivityTimer
    {
        private Stopwatch _timer;
        private List<ActivityRecord> _records;
        private ActivityRecord _current; 
        public string Name;
        private long Elapsed
        {
            get
            {
                if (this._timer != null)
                {
                    return _timer.ElapsedMilliseconds;
                } else
                {
                    return 0;
                }
            }
        }
        private TimeSpan ElapsedTime
        {
            get
            {
                return new TimeSpan(this.Elapsed);
            }
        }
        public TimeSpan TotalElaspsed
        {
            get
            {
                long total = 0;
                this._records.ForEach(r => total += r.DurationInMilliseconds);
                return new TimeSpan(total);
            }
        }
        public ActivityTimer(string Name)

        {
            this.Name = Name;
            this._timer = new Stopwatch();
            this._records = new List<ActivityRecord>();
        }

        public void StartActivity()
        {
            if (!this._timer.IsRunning)
            {
                this._current = new ActivityRecord(DateTime.Now);
                this._timer.Start();
            }
        }
        public void StopActivity()
        {
            if (_timer.IsRunning)
            {
                _timer.Stop();
                this._current.DurationInMilliseconds = this.Elapsed;
                this._records.Add(this._current);
            }
        }
        public void ResetActivity()
        {
            this._timer.Reset();
        }
    }
}

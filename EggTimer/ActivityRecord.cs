using System;
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
}

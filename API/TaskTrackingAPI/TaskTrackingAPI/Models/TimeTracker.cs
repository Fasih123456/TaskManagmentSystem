using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackingAPI.Models
{
    public class TimeTracker
    {
        public int TimeTrackedId { get; set; }

        public string WeekTracked { get; set; }

        public float HoursCompleted { get; set; }

        public float TotalHoursCompleted { get; set; }

        public int DaysReduction { get; set; }

        public float PerDay { get; set; }

        public float Change { get; set; }
    }
}

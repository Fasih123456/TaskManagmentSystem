using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackingAPI.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        public string TaskDate { get; set; }

        public string Day { get; set; }

        public string TaskName { get; set; }

        public int TimeRequired { get; set; }

        public int TimeNotSpent { get; set; }

        public string TaskStatus { get; set; }
    }
}

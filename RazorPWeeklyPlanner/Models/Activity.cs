using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPWeeklyPlanner.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int WeekDayId { get; set; }
        public WeekDay WeekDays { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPWeeklyPlanner.Models
{
    public class WeekDay
    {
        public int WeekDayId { get; set; }
        public string Day { get; set; }

        public List<Activity> Activities = new List<Activity>();

        public List<Note> Notes = new List<Note>();
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPWeeklyPlanner.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        [Display(Name = "Week ID")]
        public int WeekDayId { get; set; }
        public WeekDay WeekDays { get; set; }
    }
}

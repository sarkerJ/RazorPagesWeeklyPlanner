using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPWeeklyPlanner.Models
{
    public class WeekDay
    {
        [Display(Name ="Week ID")]
        public int WeekDayId { get; set; }
        public string Day { get; set; }

        public List<Activity> Activities = new List<Activity>();

        public List<Note> Notes = new List<Note>();
    }
}

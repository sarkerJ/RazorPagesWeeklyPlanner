using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPWeeklyPlanner.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Week Day")]
        public int WeekDayId { get; set; }
        public WeekDay WeekDays { get; set; }
    }
}

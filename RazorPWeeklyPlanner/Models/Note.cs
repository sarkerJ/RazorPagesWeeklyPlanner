using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPWeeklyPlanner.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Content { get; set; }

        [Display(Name ="Colour")]
        public int NotesColourCategoryId { get; set; }

        public NoteColourCategory NotesColourCategory { get; set; }

        [Display(Name = "Week Day")]
        public int WeekDayId { get; set; }
        public WeekDay WeekDays { get; set; }
    }
}

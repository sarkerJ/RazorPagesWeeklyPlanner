using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPWeeklyPlanner.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name ="Colour ID")]
        public int NotesColourCategoryId { get; set; }

        [Display(Name ="Colour")]
        public NoteColourCategory NotesColourCategory { get; set; }

        [Display(Name = "Week ID")]
        public int WeekDayId { get; set; }
        public WeekDay WeekDays { get; set; }
    }
}

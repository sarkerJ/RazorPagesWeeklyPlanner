using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPWeeklyPlanner.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int NotesColourCategoryId { get; set; }
        public NoteColourCategory NotesColourCategorys { get; set; }
        public int WeekDayId { get; set; }
        public WeekDay WeekDays { get; set; }
    }
}

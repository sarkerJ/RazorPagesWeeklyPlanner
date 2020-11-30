using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPWeeklyPlanner.Models
{
    public class NoteColourCategory
    {
        [Display(Name = "Colour ID")]
        public int NoteColourCategoryId { get; set; }

        public string Colour { get; set; }
    }
}

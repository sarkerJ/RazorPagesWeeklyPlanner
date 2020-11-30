using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;

namespace RazorPWeeklyPlanner.Pages.Notes
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext _context;

        public DeleteModel(RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Note
                .Include(n => n.NotesColourCategory)
                .Include(n => n.WeekDays).FirstOrDefaultAsync(m => m.NoteId == id);

            if (Note == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Note.FindAsync(id);

            if (Note != null)
            {
                _context.Note.Remove(Note);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

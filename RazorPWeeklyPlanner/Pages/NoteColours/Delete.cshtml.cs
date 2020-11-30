using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;

namespace RazorPWeeklyPlanner.Pages.NoteColours
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext _context;

        public DeleteModel(RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NoteColourCategory NoteColourCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoteColourCategory = await _context.NoteColourCategory.FirstOrDefaultAsync(m => m.NoteColourCategoryId == id);

            if (NoteColourCategory == null)
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

            NoteColourCategory = await _context.NoteColourCategory.FindAsync(id);

            if (NoteColourCategory != null)
            {
                _context.NoteColourCategory.Remove(NoteColourCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

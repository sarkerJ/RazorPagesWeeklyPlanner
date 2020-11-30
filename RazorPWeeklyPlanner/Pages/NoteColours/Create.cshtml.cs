using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;

namespace RazorPWeeklyPlanner.Pages.NoteColours
{
    public class CreateModel : PageModel
    {
        private readonly RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext _context;

        public CreateModel(RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NoteColourCategory NoteColourCategory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NoteColourCategory.Add(NoteColourCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

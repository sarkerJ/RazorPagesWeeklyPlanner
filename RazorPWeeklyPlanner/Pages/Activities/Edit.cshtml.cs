using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;

namespace RazorPWeeklyPlanner.Pages.Activities
{
    public class EditModel : PageModel
    {
        private readonly RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext _context;

        public EditModel(RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Activity Activity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity = await _context.Activity
                .Include(a => a.WeekDays).FirstOrDefaultAsync(m => m.ActivityId == id);

            if (Activity == null)
            {
                return NotFound();
            }
           ViewData["WeekDayId"] = new SelectList(_context.WeekDay, "WeekDayId", "WeekDayId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(Activity.ActivityId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ActivityExists(int id)
        {
            return _context.Activity.Any(e => e.ActivityId == id);
        }
    }
}

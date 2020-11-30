using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;

namespace RazorPWeeklyPlanner.Pages.Activities
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext _context;

        public DetailsModel(RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}

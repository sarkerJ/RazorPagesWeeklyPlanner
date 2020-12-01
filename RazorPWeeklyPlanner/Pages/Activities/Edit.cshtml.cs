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
using RazorPWeeklyPlanner.Services;

namespace RazorPWeeklyPlanner.Pages.Activities
{
    public class EditModel : PageModel
    {
        private readonly IActivityService _activityService;
        private readonly IWeekDayService _dayService;
        public EditModel(IActivityService activityService, IWeekDayService dayService)
        {
            _activityService = activityService;
            _dayService = dayService;
        }

        [BindProperty]
        public Activity Activity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity = await _activityService.GetActivityByIdAsync(id);


            if (Activity == null)
            {
                return NotFound();
            }
           ViewData["WeekDayId"] = new SelectList(_dayService.GetIEnumerableWeekDay(), "WeekDayId", "Day");
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

            _activityService.AttachActivityState(Activity, EntityState.Modified);

            try
            {
                await _activityService.UpdateActivityAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ActivityExistsAsync(Activity.ActivityId))
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

        private async Task<bool> ActivityExistsAsync(int id)
        {
            return await _activityService.ActivityDoesExistAsync(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;
using RazorPWeeklyPlanner.Services;

namespace RazorPWeeklyPlanner.Pages.Activities
{
    public class CreateModel : PageModel
    {
        private readonly IActivityService _activityService;
        private readonly IWeekDayService _dayService;


        public CreateModel(IActivityService activityService, IWeekDayService dayService)
        {
            _activityService = activityService;
            _dayService = dayService;
        }

        public IActionResult OnGet()
        {
        ViewData["WeekDayId"] = new SelectList(_dayService.GetIEnumerableWeekDay(), "WeekDayId", "Day");
            return Page();
        }

        [BindProperty]
        public Activity Activity { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _activityService.AddActivityAsync(Activity);
            await _activityService.UpdateActivityAsync();

            return RedirectToPage("./Index");
        }
    }
}

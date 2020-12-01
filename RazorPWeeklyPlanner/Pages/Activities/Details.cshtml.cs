using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;
using RazorPWeeklyPlanner.Services;

namespace RazorPWeeklyPlanner.Pages.Activities
{
    public class DetailsModel : PageModel
    {
        private readonly IActivityService _activityService;

        public DetailsModel(IActivityService activityService)
        {
            _activityService = activityService;
        }

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
            return Page();
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly IActivityService _activityService;
        private readonly IWeekDayService _dayService;

        public IndexModel(IActivityService activityService, IWeekDayService dayService)
        {
            _activityService = activityService;
            _dayService = dayService;
        }

        public IList<Activity> Activity { get;set; }
        
        [BindProperty(SupportsGet =true)]
        public string SearchString { get; set; }

        public SelectList DaysOfWeek { get; set; }

        [BindProperty(SupportsGet =true)]
        public string Day { get; set; }

        public async Task OnGetAsync()
        {


            if (!string.IsNullOrEmpty(SearchString) && !string.IsNullOrEmpty(Day))
            {
                Activity = await _activityService.GetActivitiesByStringAndDayAsync(SearchString, Day);

            }
            else if (!string.IsNullOrEmpty(SearchString))
            {
                Activity = await _activityService.GetActivitiesByStringAsync(SearchString);

            }
            else if (!string.IsNullOrEmpty(Day))
            {
                Activity = await _activityService.GetActivitiesByDayAsync(Day);
            }
            else
            {
                Activity = await _activityService.GetActivitiesAsync();
            }
            DaysOfWeek = new SelectList(await _dayService.GetDayNamesAsIEnumerable());


        }
    }
}

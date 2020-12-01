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

namespace RazorPWeeklyPlanner.Pages.WeekDays
{
    public class IndexModel : PageModel
    {
        private readonly IWeekDayService _service;

        public IndexModel(IWeekDayService service)
        {
            _service = service;
        }

        public IList<WeekDay> WeekDay { get;set; }

        public async Task OnGetAsync()
        {
            WeekDay = await _service.GetListWeekDaysAsync();
        }
    }
}

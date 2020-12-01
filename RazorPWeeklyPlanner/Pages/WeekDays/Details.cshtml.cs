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
    public class DetailsModel : PageModel
    {
        private readonly IWeekDayService _service;

        public DetailsModel(IWeekDayService service)
        {
            _service = service;
        }

        public WeekDay WeekDay { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeekDay = await _service.GetWeekDayByIdAsync(id);

            if (WeekDay == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

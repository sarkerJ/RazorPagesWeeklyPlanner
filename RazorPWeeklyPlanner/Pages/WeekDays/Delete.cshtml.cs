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
    public class DeleteModel : PageModel
    {
        private readonly IWeekDayService _service;

        public DeleteModel(IWeekDayService service)
        {
            _service = service;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeekDay = await _service.GetWeekDayByIdAsync(id);

            if (WeekDay != null)
            {
                _service.RemoveWeekDay(WeekDay);
                await _service.UpdateWeekDayAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

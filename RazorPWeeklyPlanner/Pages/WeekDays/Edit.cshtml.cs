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


namespace RazorPWeeklyPlanner.Pages.WeekDays
{
    public class EditModel : PageModel
    {
        private readonly IWeekDayService _service;

        public EditModel(IWeekDayService service)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.AttachWeekDayState(WeekDay, EntityState.Modified);


            try
            {
                await _service.UpdateWeekDayAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await WeekDayExistsAsync(WeekDay.WeekDayId))
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

        private async Task<bool> WeekDayExistsAsync(int id)
        {
            return await _service.WeekDayDoesExistsAsync(id);
        }
    }
}

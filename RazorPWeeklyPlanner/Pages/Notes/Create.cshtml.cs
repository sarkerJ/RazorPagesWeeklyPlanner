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

namespace RazorPWeeklyPlanner.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly INoteServices _noteService;
        private readonly INoteColoursService _colourService;
        private readonly IWeekDayService _dayService;


        public CreateModel(INoteServices noteService, INoteColoursService colourService, IWeekDayService dayService)
        {
            _noteService = noteService;
            _colourService = colourService;
            _dayService = dayService;
        }

       
        public IActionResult OnGet()
        {
            ViewData["NotesColourCategoryId"] = new SelectList(_colourService.GetIEnurableColourCategory(), "NoteColourCategoryId", "Colour");
            ViewData["WeekDayId"] = new SelectList(_dayService.GetIEnumerableWeekDay(), "WeekDayId", "Day");
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }
        

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _noteService.AddNoteAsync(Note);
            await _noteService.UpdateNoteAsync();

            return RedirectToPage("./Index");
        }
    }
}

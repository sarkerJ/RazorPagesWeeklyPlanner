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

namespace RazorPWeeklyPlanner.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly INoteServices _noteService;
        private readonly INoteColoursService _colourService;
        private readonly IWeekDayService _dayService;
        public EditModel(INoteServices noteService, INoteColoursService colourService, IWeekDayService dayService)
        {
            _noteService = noteService;
            _colourService = colourService;
            _dayService = dayService;
        }

        [BindProperty]
        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _noteService.GetNoteByIdAsync(id);

            if (Note == null)
            {
                return NotFound();
            }
           ViewData["NotesColourCategoryId"] = new SelectList(_colourService.GetIEnurableColourCategory(), "NoteColourCategoryId", "Colour");
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

            _noteService.AttachNoteState(Note, EntityState.Modified);


            try
            {
                await _noteService.UpdateNoteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await NoteExistsAsync(Note.NoteId))
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

        private async Task<bool> NoteExistsAsync(int id)
        {
            return await _noteService.NoteDoesExistAsync(id);
        }
    }
}

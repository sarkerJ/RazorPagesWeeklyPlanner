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

namespace RazorPWeeklyPlanner.Pages.NoteColours
{
    public class EditModel : PageModel
    {
        private readonly INoteColoursService _service;

        public EditModel(INoteColoursService service)
        {
            _service = service;
        }

        [BindProperty]
        public NoteColourCategory NoteColourCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoteColourCategory = await _service.GetNoteColourByIdAsync(id);

            if (NoteColourCategory == null)
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

            _service.AttachNoteColourState(NoteColourCategory, EntityState.Modified);

            try
            {
                await _service.UpdateNoteColourAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await NoteColourCategoryExists(NoteColourCategory.NoteColourCategoryId))
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

        private async Task<bool> NoteColourCategoryExists(int id)
        {
            return await _service.NoteColourDoesExistAsync(id);
        }
    }
}

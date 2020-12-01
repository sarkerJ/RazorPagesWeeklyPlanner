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

namespace RazorPWeeklyPlanner.Pages.NoteColours
{
    public class DeleteModel : PageModel
    {
        private readonly INoteColoursService _service;

        public DeleteModel(INoteColoursService service)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoteColourCategory = await _service.GetNoteColourByIdAsync(id);

            if (NoteColourCategory != null)
            {
                _service.RemoveNoteColour(NoteColourCategory);
                await _service.UpdateNoteColourAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

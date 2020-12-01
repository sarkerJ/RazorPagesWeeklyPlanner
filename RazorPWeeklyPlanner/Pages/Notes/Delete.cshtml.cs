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

namespace RazorPWeeklyPlanner.Pages.Notes
{
    public class DeleteModel : PageModel
    {
        private readonly INoteServices _noteService;
        public DeleteModel(INoteServices noteService)
        {
            _noteService = noteService;
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _noteService.GetNoteByIdAsync(id);

            if (Note != null)
            {
                _noteService.DeleteNote(Note);
                await _noteService.UpdateNoteAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

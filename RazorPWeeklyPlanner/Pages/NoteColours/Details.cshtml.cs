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
    public class DetailsModel : PageModel
    {
        private readonly INoteColoursService _service;

        public DetailsModel(INoteColoursService service)
        {
            _service = service;
        }

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
    }
}

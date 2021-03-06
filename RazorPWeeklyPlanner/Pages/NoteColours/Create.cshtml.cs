﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;
using RazorPWeeklyPlanner.Services;

namespace RazorPWeeklyPlanner.Pages.NoteColours
{
    public class CreateModel : PageModel
    {
        private readonly INoteColoursService _service;

        public CreateModel(INoteColoursService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NoteColourCategory NoteColourCategory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.AddNoteColourAsync(NoteColourCategory);
            await _service.UpdateNoteColourAsync();

            return RedirectToPage("./Index");
        }
    }
}

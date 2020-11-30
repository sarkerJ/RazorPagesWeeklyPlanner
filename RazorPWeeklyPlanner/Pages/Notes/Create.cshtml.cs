using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;

namespace RazorPWeeklyPlanner.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext _context;

        public CreateModel(RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }

        //public IEnumerable<SelectListItem> stringColourItems { get; set; }
       
        public IActionResult OnGet()
        {
            /*var List = _context.NoteColourCategory.ToList();

            List<SelectListItem> Test = new List<SelectListItem>();

            foreach(var item in List)
            {
                Test.Add(new SelectListItem(item.Colour, item.NoteColourCategoryId.ToString()));
            }
            stringColourItems = Test;*/


            //ViewData["NotesColourCategoryId"] = new SelectList(_context.NoteColourCategory, "NoteColourCategoryId", "NoteColourCategoryId");
            ViewData["NotesColourCategoryId"] = new SelectList(_context.NoteColourCategory, "NoteColourCategoryId", "Colour");

            //ViewData["WeekDayId"] = new SelectList(_context.WeekDay, "WeekDayId", "WeekDayId");

            ViewData["WeekDayId"] = new SelectList(_context.WeekDay, "WeekDayId", "Day");

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

            _context.Note.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

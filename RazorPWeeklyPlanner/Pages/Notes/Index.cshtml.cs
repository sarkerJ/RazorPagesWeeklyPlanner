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

namespace RazorPWeeklyPlanner.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext _context;

        public IndexModel(RazorPWeeklyPlanner.Data.RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Colours { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ColourC { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> colorNoteQ = _context.Note.OrderBy(o => o.NotesColourCategoryId)
                .Include(s => s.NotesColourCategory)
                .Select(s => s.NotesColourCategory.Colour);

            var notes =  _context.Note.AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                notes = notes.Where(s => s.Title.Contains(SearchString.Trim()));
            }
            if (!string.IsNullOrEmpty(ColourC))
            {
                notes = notes.Where(x => x.NotesColourCategory.Colour == ColourC.Trim());
            }

            Colours = new SelectList(await colorNoteQ.Distinct().ToListAsync());
            Note = await notes.Include(n => n.NotesColourCategory).Include(n => n.WeekDays).ToListAsync();

        }
    }
}

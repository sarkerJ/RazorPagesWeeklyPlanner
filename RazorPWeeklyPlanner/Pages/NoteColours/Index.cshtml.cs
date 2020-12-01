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
    public class IndexModel : PageModel
    {
        private readonly INoteColoursService _service;

        public IndexModel(INoteColoursService service)
        {
            _service = service;
        }

        public IList<NoteColourCategory> NoteColourCategory { get;set; }

        public async Task OnGetAsync()
        {
            NoteColourCategory = await _service.GetListNoteColourCategoryAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPWeeklyPlanner.Services
{
    public class NoteColoursService : INoteColoursService
    {
        private RazorPWeeklyPlannerContext _context;
        public NoteColoursService(RazorPWeeklyPlannerContext context) => _context = context;

        public async Task UpdateNoteColourAsync() => await _context.SaveChangesAsync();
        
        public async Task AddNoteColourAsync(NoteColourCategory noteColour) => await _context.NoteColourCategory.AddAsync(noteColour);

        public IEnumerable<NoteColourCategory> GetIEnurableColourCategory() => _context.NoteColourCategory.AsEnumerable<NoteColourCategory>();

        public async Task<NoteColourCategory> GetNoteColourByIdAsync(int? id) => await _context.NoteColourCategory.FirstOrDefaultAsync(m => m.NoteColourCategoryId == id);

        public void RemoveNoteColour(NoteColourCategory noteColour) => _context.NoteColourCategory.RemoveRange(noteColour);

        public void AttachNoteColourState(NoteColourCategory noteColour, EntityState state) => _context.Attach(noteColour).State = state;

        public async Task<bool> NoteColourDoesExistAsync(int id) => await _context.NoteColourCategory.AnyAsync(e => e.NoteColourCategoryId == id);

        public async Task<List<NoteColourCategory>> GetListNoteColourCategoryAsync() => await _context.NoteColourCategory.ToListAsync();
        
    }
}

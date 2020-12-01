using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPWeeklyPlanner.Services
{
    public class NoteServices : INoteServices
    {
        private RazorPWeeklyPlannerContext _context;
        public NoteServices(RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }

        public async Task AddNoteAsync(Note note)
        {
          await _context.Note.AddAsync(note);
        }

        public void AttachNoteState(Note note, EntityState state)
        {
            _context.Attach(note).State = EntityState.Modified;
        }

        public void DeleteNote(Note note)
        {
            _context.Note.RemoveRange(note);
        }

        public async Task<Note> GetNoteByIdAsync(int? id)
        {
           return await _context.Note.Include(n => n.NotesColourCategory).Include(n => n.WeekDays).FirstOrDefaultAsync(m => m.NoteId == id);
        }

        public async Task<bool> NoteDoesExistAsync(int id)
        {
            return await _context.Note.AnyAsync(e => e.NoteId == id);
        }

        public async Task UpdateNoteAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}

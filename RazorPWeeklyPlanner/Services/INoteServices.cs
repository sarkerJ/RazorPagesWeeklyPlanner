using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPWeeklyPlanner.Services
{
    public interface INoteServices
    {
        Task AddNoteAsync(Note note);

        Task UpdateNoteAsync();

        Task<Note> GetNoteByIdAsync(int? id);

        void DeleteNote(Note note);

        void AttachNoteState(Note noteColour, EntityState state);

        Task<bool> NoteDoesExistAsync(int id);

    }
}

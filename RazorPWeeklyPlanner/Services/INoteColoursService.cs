using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPWeeklyPlanner.Services
{
    public interface INoteColoursService
    {
        IEnumerable<NoteColourCategory> GetIEnurableColourCategory();

        Task AddNoteColourAsync(NoteColourCategory noteColour);

        Task UpdateNoteColourAsync();

        Task<NoteColourCategory> GetNoteColourByIdAsync(int? id);

        void RemoveNoteColour(NoteColourCategory noteColour);

        void AttachNoteColourState(NoteColourCategory noteColour, EntityState state);

        Task<bool> NoteColourDoesExistAsync(int id);

        Task<List<NoteColourCategory>> GetListNoteColourCategoryAsync();
    }
}

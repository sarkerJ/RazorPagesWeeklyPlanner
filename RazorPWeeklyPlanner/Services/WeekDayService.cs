using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;

namespace RazorPWeeklyPlanner.Services
{
    public class WeekDayService :IWeekDayService
    {
        private RazorPWeeklyPlannerContext _context;
        public WeekDayService(RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }
        public async Task UpdateWeekDayAsync() => await _context.SaveChangesAsync();
        
        public async Task AddDayAsync(WeekDay day) => await _context.WeekDay.AddAsync(day);

        public void AttachWeekDayState(WeekDay day, EntityState state) => _context.Attach(day).State = state;

        public async Task<WeekDay> GetWeekDayByIdAsync(int? id) => await _context.WeekDay.FirstOrDefaultAsync(m => m.WeekDayId == id);

        public Task<bool> WeekDayDoesExistsAsync(int id) => _context.WeekDay.AnyAsync(e => e.WeekDayId == id);

        public void RemoveWeekDay(WeekDay day) => _context.WeekDay.RemoveRange(day);

        public async Task<List<WeekDay>> GetListWeekDaysAsync() => await _context.WeekDay.ToListAsync();

        public IEnumerable<WeekDay> GetIEnumerableWeekDay()
        {
            return _context.WeekDay;
        }

        public async Task<IEnumerable<string>> GetDayNamesAsIEnumerable()
        {
            return await _context.Activity.OrderBy(o => o.WeekDayId).Include(s => s.WeekDays).Select(s => s.WeekDays.Day).Distinct().ToListAsync();

        }
    }
}

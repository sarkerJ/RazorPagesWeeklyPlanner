using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPWeeklyPlanner.Services
{
    public class ActivityService : IActivityService
    {
        private RazorPWeeklyPlannerContext _context;
        public ActivityService(RazorPWeeklyPlannerContext context)
        {
            _context = context;
        }

        public async Task<bool> ActivityDoesExistAsync(int id)
        {
            return await _context.Activity.AnyAsync(e => e.ActivityId == id);
        }

        public async Task AddActivityAsync(Activity activity)
        {
           await _context.Activity.AddAsync(activity);
        }

        public void AttachActivityState(Activity activity, EntityState state)
        {
            _context.Attach(activity).State = EntityState.Modified;
        }

        public void DeleteActivity(Activity activity)
        {
            _context.Activity.Remove(activity);
        }

        public async Task<IList<Activity>> GetActivitiesAsync()
        {
            return await _context.Activity.Include(a => a.WeekDays).ToListAsync();
        }

        public async Task<IList<Activity>> GetActivitiesByDayAsync(string Day)
        {
            return await _context.Activity.Where(w => w.WeekDays.Day == Day.Trim()).Include(a => a.WeekDays).ToListAsync();
        }

        public async Task<IList<Activity>> GetActivitiesByStringAndDayAsync(string SearchString, string Day)
        {
            return await _context.Activity.Include(a => a.WeekDays).Where(w => w.Name.Contains(SearchString.Trim()) && w.WeekDays.Day == Day).ToListAsync();
        }

        public async Task<IList<Activity>> GetActivitiesByStringAsync(string SearchString)
        {
            return await _context.Activity.Where(w => w.Name.Contains(SearchString.Trim())).Include(a => a.WeekDays).ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int? id)
        {
            return await _context.Activity.Include(a => a.WeekDays).FirstOrDefaultAsync(m => m.ActivityId == id);
        }

        public async Task UpdateActivityAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}

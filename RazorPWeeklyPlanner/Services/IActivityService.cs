using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPWeeklyPlanner.Services
{
    public interface IActivityService
    {
        Task UpdateActivityAsync();
        Task AddActivityAsync(Activity activity);
        Task<Activity> GetActivityByIdAsync(int? id);
        void DeleteActivity(Activity activity);

        void AttachActivityState(Activity activity, EntityState state);

        Task<bool> ActivityDoesExistAsync(int id);

        Task<IList<Activity>> GetActivitiesByStringAsync(string SearchString);

        Task<IList<Activity>> GetActivitiesAsync();

        Task<IList<Activity>> GetActivitiesByDayAsync(string Day);
        Task<IList<Activity>> GetActivitiesByStringAndDayAsync(string SearchString, string Day);



    }
}

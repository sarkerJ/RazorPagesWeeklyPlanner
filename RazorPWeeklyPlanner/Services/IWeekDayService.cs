using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Models;

namespace RazorPWeeklyPlanner.Services
{
    public interface IWeekDayService
    {
        Task UpdateWeekDayAsync();
        Task AddDayAsync(WeekDay day);

        Task<WeekDay> GetWeekDayByIdAsync(int? id);

        void AttachWeekDayState( WeekDay day,EntityState state);

        Task<bool> WeekDayDoesExistsAsync(int id);

        void RemoveWeekDay(WeekDay day);

        Task<List<WeekDay>> GetListWeekDaysAsync();

        IEnumerable<WeekDay> GetIEnumerableWeekDay();

        Task<IEnumerable<string>> GetDayNamesAsIEnumerable();

    }
}

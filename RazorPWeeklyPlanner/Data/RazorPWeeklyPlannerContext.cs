using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Models;

namespace RazorPWeeklyPlanner.Data
{
    public class RazorPWeeklyPlannerContext : DbContext
    {
        public RazorPWeeklyPlannerContext (DbContextOptions<RazorPWeeklyPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPWeeklyPlanner.Models.WeekDay> WeekDay { get; set; }

        public DbSet<RazorPWeeklyPlanner.Models.Activity> Activity { get; set; }

        public DbSet<RazorPWeeklyPlanner.Models.NoteColourCategory> NoteColourCategory { get; set; }

        public DbSet<RazorPWeeklyPlanner.Models.Note> Note { get; set; }
    }
}

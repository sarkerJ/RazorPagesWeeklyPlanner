using NUnit.Framework;
using Moq;
using System.Collections;
using System.Collections.Generic;
using RazorPWeeklyPlanner.Data;
using RazorPWeeklyPlanner.Models;
using RazorPWeeklyPlanner.Services;
using Microsoft.EntityFrameworkCore;
using RazorPWeeklyPlanner.Pages.Activities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;


namespace RazorPWeeklyPlannerTests
{
    public class IndexActivityTest
    {
        private IndexModel _index;

        [Test]
        [Category("ActivityIndex")]
        [Ignore("Unfinished")]
        public async Task OnGetAsync_Returns_NotFound_WhenId_IsNull()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            var mockDayService = new Mock<IWeekDayService>(MockBehavior.Strict);

            _index = new IndexModel(mockActivityService.Object, mockDayService.Object);

            //act
            mockActivityService.Setup(s => s.GetActivitiesByStringAndDayAsync("string", "Monday")).Returns(It.IsAny<Task<IList<Activity>>>());
            mockDayService.Setup(s => s.GetDayNamesAsIEnumerable()).Returns(It.IsAny<Task<IEnumerable<string>>>());


            _index.SearchString = "string";
            _index.Day = "Monday";
             await _index.OnGetAsync();


        }


        

        


    }
}
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

namespace RazorPWeeklyPlannerTests
{
    public class CreateActivityTest
    {
        //private IActivityService _activityService;
        //private IWeekDayService _dayService;
        private CreateModel _createModel;
      
        
        [Test]
        //[Ignore("Not sure what is wrong")]
        [Category("ActivityCreate")]

        public void OnGet_Returns_PageResult()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>();
            var mockDayService = new Mock<IWeekDayService>();
            //act
            WeekDay day = new WeekDay() { WeekDayId = 1, Day = "Monday" };
            IEnumerable<WeekDay> iEnumerableList = new List<WeekDay>() { day };

            mockDayService.Setup(s => s.GetIEnumerableWeekDay()).Returns(iEnumerableList);

            _createModel = new CreateModel(mockActivityService.Object, mockDayService.Object);

           

            //Assert
            Assert.That(_createModel.OnGet(), Is.InstanceOf<PageResult>());
        }








        [Test]
        [Category("ActivityCreate")]
        public async Task Testing_OnPostAsync()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>();
            var mockDayService = new Mock<IWeekDayService>();
            _createModel = new CreateModel(mockActivityService.Object, mockDayService.Object);

            //act
            mockActivityService.Setup(s => s.AddActivityAsync(It.IsAny<Activity>()));
            mockActivityService.Setup(s => s.UpdateActivityAsync());
            var result = await _createModel.OnPostAsync();

            //Assert
            Assert.That(result, Is.InstanceOf<RedirectToPageResult>());
            mockActivityService.Verify(s => s.AddActivityAsync(It.IsAny<Activity>()), Times.Exactly(1));
            mockActivityService.Verify(s => s.UpdateActivityAsync(), Times.Exactly(1));

        }
    }
}
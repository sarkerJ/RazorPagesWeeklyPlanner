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
    public class EditActivityTest
    {
        private EditModel _edit;

        [Test]
        [Category("ActivityEdit")]
        public async Task OnGetAsync_Returns_NotFound_WhenId_IsNull()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            var mockDayService = new Mock<IWeekDayService>(MockBehavior.Strict);

            _edit = new EditModel(mockActivityService.Object, mockDayService.Object);

            //act
            var result = await _edit.OnGetAsync(null);

            //Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }


        [Test]
        [Category("ActivityEdit")]
        public async Task OnGetAsync_Returns_NotFound_When_GetWeekDayByIdAsync_ReturnsNull()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            var mockDayService = new Mock<IWeekDayService>(MockBehavior.Strict);

            _edit = new EditModel(mockActivityService.Object, mockDayService.Object);

            //act
            mockActivityService.Setup(s => s.GetActivityByIdAsync(1)).ReturnsAsync(() => null);
            var result = await _edit.OnGetAsync(1);

            //Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());

        }

        [Test]
        [Category("ActivityEdit")]
        [Ignore("Similar issue to create")]
        public async Task OnGetAsync_Returns_PageResult_When_GetWeekDayByIdAsync_ReturnsAnActivity()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>();
            var mockDayService = new Mock<IWeekDayService>();
            _edit = new EditModel(mockActivityService.Object, mockDayService.Object);

            //act
            WeekDay day = new WeekDay() { WeekDayId = 1, Day = "Monday" };
            Activity activity = new Activity()
            {
                ActivityId = 1,
                Name = "Test",
                Content = "TestContent",
                WeekDayId = 1,
                WeekDays = day
            };

            IEnumerable<WeekDay> iEnumerableList = new List<WeekDay>() {day};


            mockActivityService.Setup(s => s.GetActivityByIdAsync(1)).ReturnsAsync(activity);
            mockDayService.Setup(s => s.GetIEnumerableWeekDay()).Returns(iEnumerableList);
            var result = await _edit.OnGetAsync(1);

            //Assert
            Assert.That(result, Is.InstanceOf<PageResult>());

        }


    }
}
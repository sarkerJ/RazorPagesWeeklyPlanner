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
    public class DetailsActivityTest
    {
        private DetailsModel _details;

        [Test]
        [Category("ActivityDetails")]
        public async Task OnGetAsync_Returns_NotFound_WhenId_IsNull()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            _details = new DetailsModel(mockActivityService.Object);

            //act
            var result = await _details.OnGetAsync(null);

            //Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }


        [Test]
        [Category("ActivityDetails")]
        public async Task OnGetAsync_Returns_NotFound_When_GetWeekDayByIdAsync_ReturnsNull()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            _details = new DetailsModel(mockActivityService.Object);

            //act
            mockActivityService.Setup(s => s.GetActivityByIdAsync(1)).ReturnsAsync(() => null);
            var result = await _details.OnGetAsync(1);

            //Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());

        }

        [Test]
        [Category("ActivityDetails")]
        public async Task OnGetAsync_Returns_PageResult_When_GetWeekDayByIdAsync_ReturnsAnActivity()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            _details = new DetailsModel(mockActivityService.Object);

            //act
            mockActivityService.Setup(s => s.GetActivityByIdAsync(1)).ReturnsAsync(new Activity() { ActivityId = 1 });
            var result = await _details.OnGetAsync(1);

            //Assert
            Assert.That(result, Is.InstanceOf<PageResult>());

        }


    }
}
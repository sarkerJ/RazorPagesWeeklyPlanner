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
    public class DeleteActivityTest
    {
        private DeleteModel _delete;

        [Test]
        [Category("ActivityDelete")]
        public async Task OnGetAsync_Returns_NotFound_WhenId_IsNull()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            _delete = new DeleteModel(mockActivityService.Object);

            //act
            var result = await _delete.OnGetAsync(null);

            //Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }


        [Test]
        [Category("ActivityDelete")]
        public async Task OnGetAsync_Returns_NotFound_When_GetWeekDayByIdAsync_ReturnsNull()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            _delete = new DeleteModel(mockActivityService.Object);

            //act
            mockActivityService.Setup(s => s.GetActivityByIdAsync(1)).ReturnsAsync(() => null);
            var result = await _delete.OnGetAsync(1);

            //Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());

        }

        [Test]
        [Category("ActivityDelete")]
        public async Task OnGetAsync_Returns_PageResult_When_GetWeekDayByIdAsync_ReturnsAnActivity()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            _delete = new DeleteModel(mockActivityService.Object);

            //act
            mockActivityService.Setup(s => s.GetActivityByIdAsync(1)).ReturnsAsync(new Activity() { ActivityId = 1 });
            var result = await _delete.OnGetAsync(1);

            //Assert
            Assert.That(result, Is.InstanceOf<PageResult>());

        }

        [Test]
        [Category("ActivityDelete")]
        public async Task OnPostAsync_Returns_NotFound_When_Id_ISNull()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            _delete = new DeleteModel(mockActivityService.Object);

            //act
            var result = await _delete.OnPostAsync(null);

            //Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        [Category("ActivityDelete")]
        public async Task OnPostAsync_Returns_RedirectToPageResult_When_GetWeekDayByIdAsync_ReturnsNull()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>(MockBehavior.Strict);
            _delete = new DeleteModel(mockActivityService.Object);

            //act
            mockActivityService.Setup(s => s.GetActivityByIdAsync(1)).ReturnsAsync(() => null);
            var result = await _delete.OnPostAsync(1);

            //Assert
            Assert.That(result, Is.InstanceOf<RedirectToPageResult>());

        }

        [Test]
        [Category("ActivityDelete")]
        public async Task OnPostAsync_Returns_RedirectToPageResult_When_GetWeekDayByIdAsync_ReturnsAnActivity()
        {
            //Arrange
            var mockActivityService = new Mock<IActivityService>();
            _delete = new DeleteModel(mockActivityService.Object);

            //act
            mockActivityService.Setup(s => s.GetActivityByIdAsync(1)).ReturnsAsync(new Activity() { ActivityId = 1 });
            mockActivityService.Setup(s => s.DeleteActivity(It.IsAny<Activity>()));
            mockActivityService.Setup(s => s.UpdateActivityAsync());
            var result = await _delete.OnPostAsync(1);
            
            //Assert
            Assert.That(result, Is.InstanceOf<RedirectToPageResult>());
            mockActivityService.Verify(s => s.DeleteActivity(It.IsAny<Activity>()), Times.Once);
            mockActivityService.Verify(s => s.UpdateActivityAsync(), Times.Once);
        }
    }
}
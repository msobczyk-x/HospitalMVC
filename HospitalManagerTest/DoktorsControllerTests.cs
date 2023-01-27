/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HospitalManager.Controllers;
using HospitalManager.Models;

using HospitalManager.Data;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace HospitalManagerTest
{

    public class DoktorsControllerTests
    {
        private DoktorsController _controller;
        private Mock<HospitalManagerContext> _mockContext;


        public void TestInitialize()
        {
            // Arrange
            _mockContext = new Mock<HospitalManagerContext>();
            _controller = new DoktorsController(_mockContext.Object);
        }

        [Fact]
        public async Task Index_ShouldReturnViewResult_WithListOfDoctors()
        {
            // Arrange
            var mockDoctors = new List<Doktor>()
            {
                new Doktor() { DoktorID = 1, Imie = "John", Nazwisko = "Doe" },
                new Doktor() { DoktorID = 2, Imie = "Jane", Nazwisko = "Smith" }
            };
            _mockContext.Setup(x => x.Doktor.Include(It.IsAny<Expression<Func<Doktor, object>>>()).ToListAsync())
                .Returns(Task.FromResult(mockDoctors));

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Doktor>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Details_ShouldReturnNotFound_WhenIdIsNull()
        {
            // Act
            var result = await _controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Details_ShouldReturnNotFound_WhenDoctorIsNotFound()
        {
            // Arrange
            _mockContext.Setup(x =>
                    x.Doktor.Include(It.IsAny<Expression<Func<Doktor, object>>>())
                        .FirstOrDefaultAsync(It.IsAny<Expression<Func<Doktor, bool>>>()))
                .Returns(Task.FromResult((Doktor)null));

            // Act
            var result = await _controller.Details(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
*/

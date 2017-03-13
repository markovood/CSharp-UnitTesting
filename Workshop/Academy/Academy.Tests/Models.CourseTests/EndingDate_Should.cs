using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class EndingDate_Should
    {
        [Test]
        public void NotThrowException_WhenPassedValue_IsValid()
        {
            // Arrange
            string testName = "OOP";
            int testLecturesPerWeek = 3;
            DateTime? testStartingDate = DateTime.Today;
            DateTime? testEndingDate = DateTime.Today.AddMonths(1);

            // Act & Assert
            Assert.DoesNotThrow(() => new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedValue_IsInvalid()
        {
            // Arrange
            string testName = "OOP";
            int testLecturesPerWeek = 3;
            DateTime? testStartingDate = DateTime.Today;
            DateTime? testEndingDate = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate));
        }

        [Test]
        public void CorrectlyAssign_PassedValue()
        {
            // Arrange
            string testName = "OOP";
            int testLecturesPerWeek = 3;
            DateTime? testStartingDate = DateTime.Today;
            DateTime? testEndingDate = DateTime.Today.AddMonths(1);

            // Act
            var course = new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate);

            // Assert
            Assert.AreEqual(testEndingDate, course.EndingDate);
        }
    }
}
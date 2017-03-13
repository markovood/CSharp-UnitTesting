using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class LecturesPerWeek_Should
    {
        [TestCase(-5)]
        [TestCase(9)]
        public void ThrowArgumentException_WhenPassedValue_IsInvalid(int testLecturesPerWeek)
        {
            // Arrange
            string testName = "OOP";
            DateTime testStartingDate = DateTime.Today;
            DateTime testEndingDate = testStartingDate.AddMonths(1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate));
        }

        [Test]
        public void NotThrowException_WhenPassedValue_IsValid()
        {
            // Arrange
            string testName = "OOP";
            int testLecturesPerWeek = 3;
            DateTime testStartingDate = DateTime.Today;
            DateTime testEndingDate = testStartingDate.AddMonths(1);

            // Act & Assert
            Assert.DoesNotThrow(() => new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate));
        }

        [Test]
        public void CorrectlyAssign_PassedValue()
        {
            // Arrange
            string testName = "OOP";
            int testLecturesPerWeek = 3;
            DateTime testStartingDate = DateTime.Today;
            DateTime testEndingDate = testStartingDate.AddMonths(1);

            // Act
            var course = new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate);

            // Assert
            Assert.AreEqual(testLecturesPerWeek, course.LecturesPerWeek);
        }
    }
}
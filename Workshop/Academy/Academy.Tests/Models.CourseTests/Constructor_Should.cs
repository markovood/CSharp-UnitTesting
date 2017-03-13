using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CorrectlyAssign_PassedValues()
        {
            // Arrange & Act
            string testName = "OOP";
            int testLecturesPerWeek = 2;
            DateTime testStartingDate = DateTime.Today;
            DateTime testEndingDate = testStartingDate.AddMonths(1);
            var course = new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate);

            // Assert
            Assert.AreEqual(testName, course.Name, "Name was not assigned correctly!");
            Assert.AreEqual(testLecturesPerWeek, course.LecturesPerWeek, "Lectures per week was not assigned correctly!");
            Assert.AreEqual(testStartingDate, course.StartingDate, "Starting date was not assigned correctly!");
            Assert.AreEqual(testEndingDate, course.EndingDate, "Ending date was not assigned correctly!");
        }

        [Test]
        public void CorrectlyInitialize_TheCollections()
        {
            // Arrange & Act
            string testName = "OOP";
            int testLecturesPerWeek = 2;
            DateTime testStartingDate = DateTime.Today;
            DateTime testEndingDate = testStartingDate.AddMonths(1);
            var course = new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate);

            // Assert
            Assert.IsNotNull(course.Lectures, "Lectures collection is not assigned!");
            Assert.IsNotNull(course.OnlineStudents, "OnlineStudents collection is not assigned!");
            Assert.IsNotNull(course.OnsiteStudents, "OnsiteStudents collection is not assigned!");
        }
    }
}
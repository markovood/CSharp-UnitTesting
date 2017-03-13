using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class ToString_Should
    {
        [Test]
        public void ReturnPassedDataAListOfLectures()
        {
            // Arrange
            string testName = "OOP";
            int testLecturesPerWeek = 3;
            DateTime testStartingDate = DateTime.Today;
            DateTime testEndingDate = DateTime.Today.AddMonths(1);
            var course = new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate);

            var lectureMock = new Mock<ILecture>();
            lectureMock.Setup(l => l.ToString()).Verifiable();
            course.Lectures.Add(lectureMock.Object);

            // Act
            string result = course.ToString();

            // Assert
            lectureMock.Verify(l => l.ToString(), Times.AtLeastOnce());
        }

        [Test]
        public void ReturnPassedData_AndAMesssageSayingThereAreNoLectures()
        {
            // Arrange
            string testName = "OOP";
            int testLecturesPerWeek = 3;
            DateTime testStartingDate = DateTime.Today;
            DateTime testEndingDate = DateTime.Today.AddMonths(1);
            var course = new Course(testName, testLecturesPerWeek, testStartingDate, testEndingDate);

            // Act
            string result = course.ToString();

            // Assert
            StringAssert.Contains("no lectures", result);
        }
    }
}
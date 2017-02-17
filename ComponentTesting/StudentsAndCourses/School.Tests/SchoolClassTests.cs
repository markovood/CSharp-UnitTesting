using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class SchoolClassTests
    {
        [TestMethod]
        public void Test_CreatingNewInstanceOfSchoolShouldInitializeProperties()
        {
            // Arrange & Act
            var school = new School();

            // Assert
            Assert.IsNotNull(school.Students, "Students property was not initialized!");
            Assert.IsNotNull(school.Courses, "Courses property was not initialized");
        }
    }
}

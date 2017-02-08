using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class StudentClassTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CreatingNewStudentWithNullNameShouldThrowException()
        {
            // Arrange
            var student = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CreatingNewStudentWithEmptyNameShouldThrowException()
        {
            // Arrange
            var student = new Student("", 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CreatingNewStudentWithIdLessThan10000ShouldThrowException()
        {
            // Arrange
            var student = new Student("Pesho", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CreatingNewStudentWithIdGreaterThan99999ShouldThrowException()
        {
            // Arrange
            var student = new Student("Pesho", 100000);
        }

        [TestMethod]
        public void Test_CreatingNewStudentWithValidNameAndIdShouldSetPropertiesCorrectly()
        {
            // Arrange
            var student = new Student("Pesho", 12345);
            Assert.AreEqual(12345, student.Id, "Student's ID did not set correctly!");
            Assert.AreEqual("Pesho", student.Name, "Student's Name did not set correctly!");
        }
    }
}
